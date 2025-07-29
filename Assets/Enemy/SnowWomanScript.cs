using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミー雪女クラス
/// </summary>
public class SnowWomanScript : MonoBehaviour
{
    //敵用のマネージャーのスクリプト
    private EnemyManagerScript enemyManagerScript;

    //雪女を倒したらドロップするアイテム
    public GameObject SnowWomanDropItem;

    //ドロップするアイテムの数
    public int dropItemNum = 5;

    //フリーズ用のスクリプト
    FreezeEffectScript freezeEffectScript;

    //雪女の移動方向の状態を管理する列挙型
    enum SnowWomanMoveDirectionState
    {
        Left,  // 左に移動
        Right, // 右に移動
    }

    //雪女の移動方向の状態を保持する変数
    SnowWomanMoveDirectionState moveDirectionState = SnowWomanMoveDirectionState.Left;

    //雪女の移動速度
    float moveSpeed = 3.0f;

    //雪女の移動する位置の上限
    private float moveLimit = 25.0f;

    //雪女の移動を待機する時間
    float snowWomanMoveWaitTime = 0.0f;

    //雪女の移動の間隔時間
    float snowWomanMoveInterval = 2.0f;

    //雪女のイージング前の位置
    Vector3 snowWomanPositionBeforeEasing;

    //雪女のイージング後の位置
    Vector3 snowWomanPositionAfterEasing;

    //雪女のイージングの位置の設定できたか?
    bool isSetSnowWomanPositionEasing = false;

    //雪女は移動したか?
    bool isSnowWomanMove = false;

    //雪女の移動用のイージングの割合
    float snowWomanMoveEasingTime = 0.0f;

    //雪女の動作を待機する時間
    float snowWomanActionWaitTime = 0.0f;

    //雪女の動作の間隔時間
    float snowWomanActionInterval = 0.0f;

    //雪女の体力
    public int snowWomanHP = 100;

    //雪女に対するダメージ
    public int snowWomanDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        //敵用のマネージャーのスクリプトを取得
        GameObject enemyManager = GameObject.Find("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManagerScript>();

        //雪女の移動方向の状態をランダムに設定
        moveDirectionState = (SnowWomanMoveDirectionState)Random.Range(0, 2);

        //フリーズ用のスクリプト取得
        freezeEffectScript = this.GetComponent<FreezeEffectScript>();

        //鬼の動作の間隔時間をランダムに設定
        snowWomanActionInterval = Random.Range(4, 7);
    }

    //鬼の移動処理
    void Move()
    {
        if(isSnowWomanMove)
        {
            snowWomanMoveWaitTime += Time.deltaTime;

            if(snowWomanMoveWaitTime>=snowWomanMoveInterval)
            {
                isSnowWomanMove = false;
                isSetSnowWomanPositionEasing = false;
                snowWomanMoveWaitTime = 0.0f;
            }
        }
        else
        {
            if (!isSetSnowWomanPositionEasing)
            {
                SetPositionEasing();
            }
            else
            {
                PositionEasing();
            }
        }
    }

    //位置のイージング設定
    void SetPositionEasing()
    {
        snowWomanPositionBeforeEasing = transform.position;
        snowWomanPositionAfterEasing = transform.position;

        //画面外に出たら反対側に移動する
        if (transform.position.x <= -moveLimit)
        {
            moveDirectionState = SnowWomanMoveDirectionState.Right;
        }
        else if (transform.position.x >= moveLimit)
        {
            moveDirectionState = SnowWomanMoveDirectionState.Left;
        }

        switch (moveDirectionState)
        {
            case SnowWomanMoveDirectionState.Left:
                snowWomanPositionAfterEasing.x = transform.position.x - 5.0f;
                break;
            case SnowWomanMoveDirectionState.Right:
                snowWomanPositionAfterEasing.x = transform.position.x + 5.0f;
                break;
        }

        snowWomanMoveEasingTime = 0.0f;
        isSetSnowWomanPositionEasing = true;
    }

    //位置のイージング処理
    void PositionEasing()
    {
        snowWomanMoveEasingTime += moveSpeed * Time.deltaTime;

        if(snowWomanMoveEasingTime>1.0f)
        {
            snowWomanMoveEasingTime = 1.0f;
            isSnowWomanMove = true;
        }

        transform.position = Vector3.Lerp
        (
            snowWomanPositionBeforeEasing, 
            snowWomanPositionAfterEasing, 
            snowWomanMoveEasingTime
        );
    }

    //鬼の動作処理
    void Action()
    {
        //トルネードを生成していないときに処理する
        if (!freezeEffectScript.IsActive())
        {
            snowWomanActionWaitTime += Time.deltaTime;

            if (snowWomanActionWaitTime >= snowWomanActionInterval)
            {
                freezeEffectScript.Spawn();
                snowWomanActionInterval = Random.Range(4, 7);
                snowWomanActionWaitTime = 0.0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="coin(Clone)")
        {
            snowWomanHP -= snowWomanDamage;

            if (snowWomanHP <= 0)
            {
                if (freezeEffectScript.IsActive())
                {
                    Destroy(freezeEffectScript.GetFreezeEffect());
                }
                Destroy(gameObject);

                for (int i = 0; i < dropItemNum; i++)
                {
                    //雪女を倒したらドロップアイテムを生成
                    Vector3 dropItemPosition = new Vector3(Random.Range(-23.0f, 23.0f), 15.0f, Random.Range(-4.0f, 1.0f));
                    Instantiate(SnowWomanDropItem, dropItemPosition, Quaternion.identity);
                }

                enemyManagerScript.EnemyInactive();//敵用のマネージャーのスクリプトに敵が非アクティブになったことを通知する
                enemyManagerScript.EnemyEventFinish();//敵のイベントが終わったことを通知する
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyManagerScript.IsEnemyLifeTimiLimit())
        {
            if (freezeEffectScript.IsActive())
            {
                Destroy(freezeEffectScript.GetFreezeEffect());
            }
            Destroy(gameObject);

            enemyManagerScript.EnemyInactive();//敵用のマネージャーのスクリプトに敵が非アクティブになったことを通知する
            enemyManagerScript.ResetEnemyLifeTimeLimit();//敵の生存時間を超えたかどうかを管理するフラグをリセットする
            enemyManagerScript.EnemyEventFinish();//敵のイベントが終わったことを通知する
        }

        Move();//雪女の移動処理

        Action();//雪女の動作処理
    }
}

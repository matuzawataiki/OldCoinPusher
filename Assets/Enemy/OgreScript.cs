using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミー鬼クラス
/// </summary>
public class OgreScript : MonoBehaviour
{
    //敵用のマネージャーのスクリプト
    private EnemyManagerScript enemyManagerScript;

    //鬼を倒したらドロップするアイテム
    public GameObject OgreDropItem;

    //トルネード用のスクリプト
    TornadoEffectScript tornadoEffectScript;

    //鬼の移動方向の状態を管理する列挙型
    enum OgreMoveDirectionState
    {
        Left,  // 左に移動
        Right, // 右に移動
    }

    //鬼の移動方向の状態を保持する変数
    OgreMoveDirectionState moveDirectionState = OgreMoveDirectionState.Left;

    //鬼の移動速度
    float moveSpeed = 10.0f;

    //鬼の移動する位置の上限
    private float moveLimit = 25.0f;

    //鬼の動作を待機する時間
    float ogreActionWaitTime = 0.0f;

    //鬼の動作の間隔時間
    float ogreActionInterval = 0.0f;

    //鬼の体力
    public int ogreHP = 100;

    //鬼に対するダメージ
    public int ogreDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        //敵用のマネージャーのスクリプトを取得
        GameObject enemyManager = GameObject.Find("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManagerScript>();

        //鬼の移動方向の状態をランダムに設定
        moveDirectionState = (OgreMoveDirectionState)Random.Range(0, 2);

        //トルネード用のスクリプト取得
        tornadoEffectScript = this.GetComponent<TornadoEffectScript>();

        //鬼の動作の間隔時間をランダムに設定
        ogreActionInterval = Random.Range(4, 7);
    }

    //鬼の移動処理
    void Move()
    {
        //鬼の移動方向に応じて移動処理を行う
        switch (moveDirectionState)
        {
            case OgreMoveDirectionState.Left:
                transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                break;
            case OgreMoveDirectionState.Right:
                transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                break;
        }

        //画面外に出たら反対側に移動する
        if (transform.position.x < -moveLimit)
        {
            moveDirectionState = OgreMoveDirectionState.Right;
        }
        else if (transform.position.x > moveLimit)
        {
            moveDirectionState = OgreMoveDirectionState.Left;
        }
    }

    //鬼の動作処理
    void Action()
    {
        //トルネードを生成していないときに処理する
        if (!tornadoEffectScript.IsActive())
        {
            ogreActionWaitTime += Time.deltaTime;

            if (ogreActionWaitTime >= ogreActionInterval)
            {
                tornadoEffectScript.Spawn();
                ogreActionInterval = Random.Range(4, 7);
                ogreActionWaitTime = 0.0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coin(Clone)")
        {
            ogreHP -= ogreDamage;

            if (ogreHP <= 0)
            {
                if (tornadoEffectScript.IsActive())
                {
                    Destroy(tornadoEffectScript.GetTornadoEffect());
                }
                Destroy(gameObject);

                //鬼を倒したらドロップアイテムを生成
                Vector3 dropItemPosition = transform.position;
                dropItemPosition.y += 1.0f; // ドロップアイテムの位置を少し上に設定
                Instantiate(OgreDropItem, dropItemPosition, OgreDropItem.transform.rotation);

                enemyManagerScript.EnemyInactive();//敵用のマネージャーのスクリプトに敵が非アクティブになったことを通知する
                enemyManagerScript.EnemyEventFinish();//敵のイベントが終わったことを通知する
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyManagerScript.IsEnemyLifeTimiLimit())
        {
            if (tornadoEffectScript.IsActive())
            {
                Destroy(tornadoEffectScript.GetTornadoEffect());
            }
            Destroy(gameObject);

            enemyManagerScript.EnemyInactive();//敵用のマネージャーのスクリプトに敵が非アクティブになったことを通知する
            enemyManagerScript.ResetEnemyLifeTimeLimit();//敵の生存時間を超えたかどうかを管理するフラグをリセットする
            enemyManagerScript.EnemyEventFinish();//敵のイベントが終わったことを通知する
        }

        Move();//鬼の移動処理

        Action();//鬼の動作処理
    }
}

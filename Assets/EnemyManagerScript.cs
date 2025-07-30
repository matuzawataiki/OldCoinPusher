using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    //敵の種類
    enum EnemyType
    {
        Ogre,//鬼
        SnowWoman,//雪女
        Num//敵の数
    }

    //敵のオブジェクトを格納する配列
    public GameObject[] enemyObjects = new GameObject[(int)EnemyType.Num];

    //プッシャーマネージャースクリプトを格納する変数
    private PusherManagerScript pusherManagerScript;

    //敵の生成する位置を格納する配列
    private float[] enemySpawnPositionX = new float[9] { -20.0f, -15.0f, -10.0f, -5.0f, 0.0f, 5.0f, 10.0f, 15.0f, 20.0f };

    //セーブデータ
    public GameObject saveData;
    private SaveData saveDataScript;

    //敵がアクティブ状態かを管理するフラグ
    private bool isEnemyActive = false;

    //敵を生成する用のコインのカウント
    int enemySpawnCoinCount = 0;

    //敵を生成するコインの数
    public int enemySpawnCoinNum = 100;

    //敵が生成してからの時間(秒)
    private float enemySpawnTime = 0.0f;

    //敵の生存時間(秒)
    public float enemyLifeTimeLimit = 60.0f;

    //敵の生存時間を超えたかどうかを管理するフラグ
    bool isEnemyLifeTimeLimit = false;

    //プレイヤーの攻撃力
    int playerAtackPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        saveDataScript = saveData.GetComponent<SaveData>();

        GameObject eventStand = GameObject.Find("Stage");
        pusherManagerScript = eventStand.transform.Find("Pusher").GetComponent<PusherManagerScript>();
    }

    //敵を消すかどうか？
    public bool IsEnemyLifeTimiLimit()
    {
        return isEnemyLifeTimeLimit;
    }

    //敵の生存時間を超えたかどうかを管理するフラグをリセットする処理
    public void ResetEnemyLifeTimeLimit()
    {
        isEnemyLifeTimeLimit = false;
    }

    //敵を生成する用のコインをカウントする処理
    public void AddEnemySpawnCoinCount(int coin)
    {
        enemySpawnCoinCount += coin;
    }

    //敵を生成する用のコインのカウントをリセットする処理
    public void ResetEnemySpawnCoinCount()
    {
        enemySpawnCoinCount = 0;
    }

    //敵を非アクティブ状態にする処理
    public void EnemyInactive()
    {
        isEnemyActive = false;
    }

    //敵がアクティブ状態かの取得
    public bool IsEnemyActive()
    {
        return isEnemyActive;
    }

    //プレイヤーの攻撃力をアップグレードする処理
    public void UpgradePlayerAtackPower(int upgrade)
    {
        playerAtackPower += upgrade;
    }

    //プレイヤーの攻撃力をダウングレードする処理
    public void DowngradePlayerAtackPower(int downgrade)
    {
        playerAtackPower -= downgrade;
    }

    //敵が食らうダメージの取得
    public int GetPlayerAtackPower()
    {
        return playerAtackPower;
    }

    //敵のイベントが終わった時の処理
    public void EnemyEventFinish()
    {
        pusherManagerScript.Close();
    }

    //敵を生成する処理
    void EnemySpawn()
    {
        //敵をランダムに選択
        int enemyObj = Random.Range(0, (int)EnemyType.Num);
        //敵のオブジェクトを生成する位置をランダムに決定(Z軸の位置は後で変える)
        Vector3 spawnPosition = new Vector3(enemySpawnPositionX[Random.Range(0, enemySpawnPositionX.Length)], 12.0f, 5.0f);
        //敵のオブジェクトを生成
        GameObject enemy = Instantiate(enemyObjects[enemyObj], spawnPosition, Quaternion.identity);
        //敵をアクティブ状態にする
        isEnemyActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnemyActive)
        {
            if (pusherManagerScript.GetEventStandState() != PusherManagerScript.EventStandState.Close)
            {
                if (enemySpawnCoinCount >= enemySpawnCoinNum)
                {
                    if (pusherManagerScript.IsOpenFinish())
                    {
                        EnemySpawn();
                    }
                    else if (!pusherManagerScript.IsOpen())
                    {
                        pusherManagerScript.Open();
                    }
                }
            }
            else
            {
                if(pusherManagerScript.IsCloseFinish())
                {
                    ResetEnemySpawnCoinCount();
                }
                else if (!pusherManagerScript.IsClose())
                {
                    pusherManagerScript.Close();
                }
            }
        }
        else
        {
            //敵がアクティブ状態のときは敵の生成時間をカウントする
            enemySpawnTime += Time.deltaTime;
            //敵の生存時間を超えたら敵を消す
            if (enemySpawnTime >= enemyLifeTimeLimit)
            {
                isEnemyLifeTimeLimit = true;
                enemySpawnTime = 0.0f; //敵の生成時間をリセット
            }
        }
    }
}

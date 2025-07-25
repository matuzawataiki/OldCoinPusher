using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPusherScript : MonoBehaviour
{
    //コイン発射用の変数一覧
    //コインオブジェクトを格納する変数
    public GameObject coinObject;

    //コインの発射速度
    float coinShotSpeed = 800.0f;

    //コインを発射を制限するフラグ
    bool shotCoinLimitFlag = false;

    //自動でコインを発射するフラグ
    bool autoShotCoinFlag = false;

    //コインを発射できる間隔（秒）
    float shotCoinInterval = 0.3f;

    //コインを発射できる間隔のタイマー
    float shotCoinTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //コインを発射する処理
    void ShotCoin()
    {
        //手動でコインを発射しているとき
        if (!autoShotCoinFlag)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                //自動でコインを発射するように切り替える
                autoShotCoinFlag = true;
            }
        }
        //自動でコインを発射しているとき
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                //手動でコインを発射するように切り替える
                autoShotCoinFlag = false;
            }
        }

        //コインの発射を制限されていない場合は、コインを発射できる
        if (!shotCoinLimitFlag)
        {
            if (Input.GetKey(KeyCode.Space) || autoShotCoinFlag)
            {
                //コインオブジェクトを生成する処理
                CreateCoinObject();

                //コインの発射を制限する
                shotCoinLimitFlag = true;
            }
        }
        //コインの発射を制限されている場合は、コインの発射を制限する
        else
        {
            //コインの発射を制限する時間の更新
            shotCoinTimer += Time.deltaTime;

            //コインの発射を制限する時間が経過した場合、コインの発射を制限を解除する
            if (shotCoinTimer >= shotCoinInterval)
            {
                shotCoinLimitFlag = false;
                shotCoinTimer = 0.0f;
            }
        }
    }

    //コインオブジェクトを生成する処理
    void CreateCoinObject()
    {
        //コインの発射位置をプレイヤーの前方に設定
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //コインオブジェクトを生成し、プレイヤーの前方に発射する
        GameObject coin = Instantiate(coinObject, playerPos, Quaternion.identity);

        //コインのRigidbodyコンポーネントの取得
        Rigidbody coinRigidbody = coin.GetComponent<Rigidbody>();

        //コインのRigidbodyに力を加えて、コインを前方に発射する
        coinRigidbody.AddForce(transform.forward * coinShotSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        ShotCoin();//コインを発射する処理
    }
}

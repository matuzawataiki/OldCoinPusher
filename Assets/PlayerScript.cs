using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤークラス
/// </summary>
public class PlayerScript : MonoBehaviour
{
    //移動用の変数一覧
    //プレイヤーの移動速度
    float moveSpeed = 5.0f;


    //回転用の変数一覧
    //プレイヤーの回転速度
    float rotationSpeed = 45.0f;

    //プレイヤーの現在のX軸の角度を格納する変数
    private float currentRotationX = 0.0f;

    //プレイヤーの現在のY軸の角度を格納する変数
    private float currentRotationY = 0.0f;


    //コイン発射用の変数一覧
    //コインオブジェクトを格納する変数
    public GameObject coinObject;

    //コインの発射速度
    float coinShotSpeed = 500.0f;

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

    //プレイヤーの移動処理
    void Move()
    {
        //右移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        //左移動
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
    }

    //プレイヤーの回転処理
    void Rotation()
    {
        //上回転
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-rotationSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        //下回転
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        MoveRotationXLimit();//プレイヤーのX軸の回転を制限する処理

        //左回転
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f, Space.World);
        }

        //右回転
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f, Space.World);
        }

        MoveRotationYLimit();//プレイヤーのY軸の回転を制限する処理
    }

    //プレイヤーのX軸の回転を制限する処理
    void MoveRotationXLimit()
    {
        //プレイヤーの現在のX軸の角度を取得
        currentRotationX = transform.rotation.eulerAngles.x;
        //角度が-180～180の範囲内になるように補正
        if (currentRotationX > 180.0f)
        {
            currentRotationX -= 360.0f;
        }

        //X軸の回転を制限
        currentRotationX = Mathf.Clamp(currentRotationX, -30.0f, 30.0f);
        transform.localEulerAngles = new Vector3(currentRotationX, transform.localEulerAngles.y, 0.0f);
    }

    //プレイヤーのY軸の回転を制限する処理
    void MoveRotationYLimit()
    {
        //プレイヤーの現在のY軸の角度を取得
        currentRotationY = transform.rotation.eulerAngles.y;
        //角度が-180～180の範囲内になるように補正
        if (currentRotationY > 180.0f)
        {
            currentRotationY -= 360.0f;
        }

        //Y軸の回転を制限
        currentRotationY = Mathf.Clamp(currentRotationY, -30.0f, 30.0f);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentRotationY, 0.0f);
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
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);

        //コインオブジェクトを生成し、プレイヤーの前方に発射する
        GameObject coin = Instantiate(coinObject, playerPos, Quaternion.identity);

        //コインのRigidbodyコンポーネントの取得
        Rigidbody coinRigidbody = coin.GetComponent<Rigidbody>();

        //コインのRigidbodyに力を加えて、コインを前方に発射する
        coinRigidbody.AddForce(transform.forward * coinShotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();//プレイヤーの移動処理

        Rotation();//プレイヤーの回転処理

        ShotCoin();//コインを発射する処理
    }
}

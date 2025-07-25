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
    float moveSpeed = 10.0f;

    //プレイヤーの現在のX軸の位置を格納する変数
    private float currentPositionX = 0.0f;

    //プレイヤーの移動制限距離
    public float moveLimit = 15.0f;

    //回転用の変数一覧
    //プレイヤーの回転速度
    float rotationSpeed = 45.0f;

    //プレイヤーの現在のX軸の角度を格納する変数
    private float currentRotationX = 0.0f;

    //プレイヤーの現在のY軸の角度を格納する変数
    private float currentRotationY = 0.0f;

    //プレイヤーの回転制限角度
    public float rotationLimit = 30.0f;

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

        MovePositionXLimit();//プレイヤーのX軸の移動を制限する処理
    }

    //プレイヤーのX軸の移動を制限する処理
    void MovePositionXLimit()
    {
        //プレイヤーの現在のX軸の位置を取得
        currentPositionX = transform.position.x;

        //X軸の移動を制限
        currentPositionX = Mathf.Clamp(currentPositionX, -moveLimit, moveLimit);
        transform.position = new Vector3(currentPositionX, transform.position.y, transform.position.z);
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
        currentRotationX = Mathf.Clamp(currentRotationX, -rotationLimit, rotationLimit);
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
        currentRotationY = Mathf.Clamp(currentRotationY, -rotationLimit, rotationLimit);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentRotationY, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();//プレイヤーの移動処理

        Rotation();//プレイヤーの回転処理
    }
}

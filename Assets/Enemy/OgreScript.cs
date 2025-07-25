using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミー鬼クラス
/// </summary>
public class OgreScript : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
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

    //鬼の動作
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

    // Update is called once per frame
    void Update()
    {
        Move();//鬼の移動処理

        Action();//鬼の動作
    }
}

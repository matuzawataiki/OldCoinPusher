using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// トルネードのエフェクトを制御するクラス
/// </summary>
public class TornadoEffectScript : MonoBehaviour
{
    //トルネードのエフェクト
    public GameObject tornadoEffect;
    //トルネードのエフェクトのデータを格納する変数
    private GameObject tornadoEffectData;

    //トルネードの状態を管理する列挙型
    enum TornadoState
    {
        None,// 何もしない
        Move // 移動状態
    }

    //トルネードの移動状態を管理する列挙型
    enum TornadoMoveDirectionState
    {
        Left, //右に移動
        Right //左に移動
    }

    //トルネードの状態を管理する変数
    TornadoState tornadoState = TornadoState.None;

    //トルネードの移動状態を管理する変数
    TornadoMoveDirectionState tornadoMoveDirectionState = TornadoMoveDirectionState.Left;

    //トルネードの生存時間
    float tornadoLifeTime = 0.0f;
    
    //トルネードを消滅する時間
    float tornadoDestroyTime = 4.0f;

    //トルネードを生成しているかどうかを管理するフラグ
    bool isTornadoActive = false;

    // Start is called before the first frame update
    void Start()
    {
        tornadoEffectData = tornadoEffect;
    }

    //トルネードの移動処理
    void TornadoMove()
    {
        if (tornadoMoveDirectionState == TornadoMoveDirectionState.Left)
        {
            //トルネードを左に移動させる
            tornadoEffect.transform.Translate(Vector3.left * 0.5f * Time.deltaTime, Space.World);
        }
        else if (tornadoMoveDirectionState == TornadoMoveDirectionState.Right)
        {
            //トルネードを右に移動させる
            tornadoEffect.transform.Translate(Vector3.right * 0.5f * Time.deltaTime, Space.World);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //トルネードがアクティブな場合の処理
        if (isTornadoActive)
        {
            //トルネードの状態が移動状態のとき
            if(tornadoState == TornadoState.Move)
            {
                TornadoMove();//トルネードの移動処理
            }

            //トルネードの生存時間の更新
            tornadoLifeTime += Time.deltaTime;

            //トルネードの生存時間が0秒になったらトルネードを消滅する
            if (tornadoLifeTime >= tornadoDestroyTime)
            {
                //トルネードのエフェクトを削除する
                Destroy(tornadoEffect);

                //トルネードのエフェクトを初期状態に戻す
                tornadoEffect = tornadoEffectData;

                //トルネードの生存時間をリセットする
                tornadoLifeTime = 0.0f;

                //トルネードの状態をリセットする
                isTornadoActive = false;
            }
        }
        // トルネードがアクティブでない場合の処理
        else
        {
            //デバッグ用のトルネード生成
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //トルネードのエフェクトを生成する
                tornadoEffect = Instantiate(tornadoEffect, tornadoEffect.transform.position, Quaternion.identity);

                //トルネードのエフェクトのスケールを調整する
                Vector3 tornadoEffectScale = tornadoEffect.transform.localScale;
                tornadoEffectScale *= 1.5f;
                tornadoEffect.transform.localScale = tornadoEffectScale;

                //トルネードの状態をランダムに設定する
                tornadoState = (TornadoState)Random.Range(0, 2);

                //トルネードの状態が移動状態のとき
                if (tornadoState == TornadoState.Move)
                {
                    //トルネードの移動状態をランダムに設定する
                    tornadoMoveDirectionState = (TornadoMoveDirectionState)Random.Range(0, 2);
                }

                //トルネードの状態をアクティブにする
                isTornadoActive = true;
            }
        }
    }
}

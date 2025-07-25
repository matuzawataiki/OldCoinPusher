using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フリーズのエフェクトを制御するクラス
/// </summary>
public class FreezeEffectScript : MonoBehaviour
{
    //フリーズのエフェクト
    public GameObject freezeEffect;
    //フリーズのエフェクトのデータを格納する変数
    private GameObject freezeEffectData;

    //フリーズの生存時間
    float freezeLifeTime = 0.0f;

    //フリーズを消滅する時間
    float freezeDestroyTime = 2.0f;

    //フリーズを生成しているかどうかを管理するフラグ
    bool isFreezeActive = false;

    //フリーズを生成するかどうかを管理するフラグ
    bool isFreezeSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        freezeEffectData = freezeEffect;
    }

    //フリーズ生成している？
    public bool IsActive()
    {
        return isFreezeActive;
    }

    //フリーズの生成
    public void Spawn()
    {
        isFreezeSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFreezeActive)
        {
            //フリーズの生存時間の更新
            freezeLifeTime += Time.deltaTime;

            //トルネードの生存時間が0秒になったらフリーズを消滅する
            if (freezeLifeTime >= freezeDestroyTime)
            {
                //フリーズのエフェクトを削除する
                Destroy(freezeEffect);

                //フリーズのエフェクトを初期状態に戻す
                freezeEffect = freezeEffectData;

                //フリーズの生存時間をリセットする
                freezeLifeTime = 0.0f;

                //フリーズの状態をリセットする
                isFreezeActive = false;
            }
        }
        else
        {
            //フリーズ生成
            if (isFreezeSpawn)
            {
                Vector3 freezeEffectPos = transform.position;
                freezeEffectPos.z += 2.5f;

                //フリーズエフェクトを生成
                freezeEffect = Instantiate(freezeEffect, freezeEffectPos, freezeEffect.transform.rotation);

                //フリーズの状態をアクティブにする
                isFreezeActive = true;

                //フリーズ生成できた
                isFreezeSpawn = false;
            }
        }
    }
}

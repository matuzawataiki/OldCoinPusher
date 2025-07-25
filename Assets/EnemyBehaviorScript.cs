using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// エネミーの特性によるコインの挙動を制御するクラス
/// </summary>
public class EnemyBehaviorScript : MonoBehaviour
{
    //コイン凍結用の変数一覧
    //コインの凍結時間
    float coinFreezeTime = 0.0f;
    //コインを解凍する時間
    float coinUnfreezeTime = 5.0f;
    //コインの凍結状態を管理するフラグ
    bool isCoinFreeze = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.name == "Tornado(Clone)")
        {
            Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 20.0f, ForceMode.Impulse);
        }
        else if(other.transform.parent.name == "Freeze(Clone)")
        {
            CoinFreeze();//コインを凍結する処理
        }
    }

    //コインを凍結する処理
    void CoinFreeze()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.blue;
        Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        isCoinFreeze = true;
    }

    // コインを解凍する処理
    void CoinUnFreeze()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
        Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        isCoinFreeze = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCoinFreeze)
        {
            coinFreezeTime += Time.deltaTime;
            //コインの凍結時間が解凍時間を超えたら解凍する
            if (coinFreezeTime >= coinUnfreezeTime)
            {
                CoinUnFreeze();//コインを解凍する処理
                coinFreezeTime = 0.0f;
            }
        }
    }
}

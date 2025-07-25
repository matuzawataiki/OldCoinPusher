using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//
enum PrizeType
{
    pig = 0,//豚の貯金箱
    bag = 1,//バッグ
    Hat = 2,//帽子
    HedPhone = 3,//ヘッドフォン
    Crown = 4,//王冠
    numberOfPrizeType = 5 //賞品の種類の数
}
public class SerectPrizeScript : MonoBehaviour
{
    [SerializeField] GameObject [] prize = new GameObject[(int)PrizeType.numberOfPrizeType];
    bool isGetTaru = false; // たるを取得したかどうかのフラグ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGetTaru == true)
        {
            int rand = Random.Range(0, (int)PrizeType.numberOfPrizeType);
            Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 15.0f, Random.Range(-5.0f, 5.0f));
            GameObject prizeObj = Instantiate(prize[rand], pos, Quaternion.identity);
            isGetTaru = false; //
        }
    }
}

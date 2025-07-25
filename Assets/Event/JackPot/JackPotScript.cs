using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WhichJackPotItem
{
    Tawara = 0, //俵。
    Coin = 1, //小判束
    numberOfJackPotItem //ジャックポットの景品の数
}

public class JackPotScript : MonoBehaviour
{
    [SerializeField] GameObject[] JackPotStartDropItem=new GameObject [2]; //ジャックポットの景品の配列
    int NowJackPotSceneIsTriggerToSpace = 0; //スペースキーを押した回数をカウントする変数
    float JackPotTime = 10.0f; //ジャックポット継続時間
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, (int)WhichJackPotItem.numberOfJackPotItem);
        Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 15.0f, Random.Range(-5.0f, 5.0f));
        GameObject JackPotObj = Instantiate(JackPotStartDropItem[rand], pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //ジャックポットの時間をカウントダウンする。
        if (JackPotTime > 0.0f) {
            JackPotTime -= Time.deltaTime;
            //スペースキーを押した回数のカウント
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NowJackPotSceneIsTriggerToSpace += 1;
            }
        } 
        else {
            NowJackPotSceneIsTriggerToSpace = 0; //ジャックポットの時間が終わったらスペースキーを押した回数をリセットする。
        }
        
    }
}

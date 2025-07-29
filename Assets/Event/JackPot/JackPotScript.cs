using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    float intervalTime = 0.3f;//間隔時間(秒)
    float jackPotTimer = 0.0f;//経過時間(秒)
    bool isJackPotDropItemCreate = false;//ジャックポットの景品を生成したかどうかのフラグ
    SaveData saveDataScript;
    EventManagerScript eventManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        eventManagerScript = GameObject.Find("EventManager").transform.GetComponent<EventManagerScript>();
    }

    //セーブデータスクリプトを設定する処理
    public void SetSaveData(SaveData saveData)
    {
        saveDataScript = saveData;
    }

    //ジャックポットの景品をランダムにドロップする処理
    void JackPotDropItem()
    {
        int rand = Random.Range(0, (int)WhichJackPotItem.numberOfJackPotItem);
        Vector3 pos = new Vector3(Random.Range(-20.0f, 21.0f), 10.0f, Random.Range(-5.0f, 0.1f));
        GameObject JackPotObj = Instantiate(JackPotStartDropItem[rand], pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //ジャックポットの景品を生成する処理
        if (saveDataScript.GetJackpot() > 0) {
            //ジャックポットの景品の生成を制限するフラグが立っていない場合
            if (!isJackPotDropItemCreate)
            {
                //コインオブジェクトを生成する処理
                saveDataScript.SubtractJackpot(1);
                JackPotDropItem();

                //ジャックポットの景品の生成を制限する
                isJackPotDropItemCreate = true;
            }
            //ジャックポットの景品の生成を制限するフラグが立っている場合
            else
            {
                //ジャックポットの景品の生成を制限する時間の更新
                jackPotTimer += Time.deltaTime;

                //ジャックポットの景品の生成を制限する時間が経過した場合、コインの発射を制限を解除する
                if (jackPotTimer >= intervalTime)
                {
                    isJackPotDropItemCreate = false;
                    jackPotTimer = 0.0f;
                }
            }
        } 
        else {
            eventManagerScript.IsJackPotActive = false;
            Destroy(gameObject);
            saveDataScript.SetJackpot(false);
        }
        
    }
}

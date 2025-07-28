using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

enum EventType
{
    JackPotActive, //ジャックポット
    EnemyEncounter, //敵出現
    SkellEncounter, //スケルトン出現
    OkeEncounter, //上段に桶出現
}

//イベント出現のマネージャースクリプト。
public class EventManagerScript : MonoBehaviour
{
    const int EnemyEncounterCoin = 15; //敵が出現するのに必要なコイン数
    const int SkellEncounterCoin = 40; //スケルトンが出現するのに必要なコイン数
    const int OkeEncounterCoin = 60; //上段に桶が出現するのに必要なコイン数
    const int JackPotActiveteCoban = 5; //ジャックポットが出現するのに必要な小判束数
    public bool IsEnemyEncounter = false; //敵出現イベントがアクティブどうか
    public bool IsSkellEncounter = false; //スケルトン出現イベントがアクティブどうか
    public bool IsOkeEncounter = false; //上段に桶出現イベントがアクティブどうか
    public bool IsJackPotActive = false; //ジャックポットイベントがアクティブどうか
    int coinCount = 0; //コインの数をカウントする変数
    int cobanCount = 0; //小判の数をカウントする変数
    private bool IsOpen = false; //上段が開いているかどうかのフラグ
    [SerializeField]GameObject[] NowEvent=new GameObject[4]; //現在起きているイベントを格納する変数
    [SerializeField] GameObject SaveDataObject;
    [SerializeField] GameObject StageObject; //ステージオブジェクトを格納する変数
    SaveData SaveDataScript; //セーブデータスクリプトを格納する変数 
    PusherManagerScript  StageScript; //ステージスクリプトを格納する変数

    // Start is called before the first frame update
    void Start()
    {
        SaveDataScript = SaveDataObject.GetComponent<SaveData>(); //セーブデータスクリプトを取得
        StageScript = StageObject.GetComponent<PusherManagerScript>(); //ステージスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        coinCount = SaveDataScript.GetCoin(); //コインの数を取得
        cobanCount = SaveDataScript.GetCoban(); //小判の数を取得

        OpenOrCloseUpperRow(); //上段の開閉を行う
        if (cobanCount != 0)
        {
            if (cobanCount % JackPotActiveteCoban == 0 && IsJackPotActive == false)
            {
                GameObject gameObject = Instantiate(NowEvent[(int)EventType.JackPotActive], transform.position, Quaternion.identity);
                IsJackPotActive = true; //ジャックポットイベントがアクティブになる
            }
        }
        if (coinCount != 0)
        {
            if (coinCount % EnemyEncounterCoin == 0 && IsEnemyEncounter == false)
            {
                GameObject gameObject = Instantiate(NowEvent[(int)EventType.EnemyEncounter], transform.position, Quaternion.identity);
                IsEnemyEncounter = true; //敵出現イベントがアクティブになる
            }
            if (coinCount % SkellEncounterCoin == 0 && IsSkellEncounter == false)
            {
                GameObject gameObject = Instantiate(NowEvent[(int)EventType.SkellEncounter], transform.position, Quaternion.identity);
                IsSkellEncounter = true; //スケルトン出現イベントがアクティブになる
            }
            if (coinCount % OkeEncounterCoin == 0 && IsOkeEncounter == false)
            {
                GameObject gameObject = Instantiate(NowEvent[(int)EventType.OkeEncounter], transform.position, Quaternion.identity);
                //IsOkeEncounter = true; //上段に桶出現イベントがアクティブになる。BuketScriptからfalseに戻せないため一旦コメントアウト。
            }
        }
    }

    private void OpenOrCloseUpperRow()
    {
        if ((IsEnemyEncounter == false && IsSkellEncounter == false && IsOkeEncounter == false)&&IsOpen==true)
        {
            StageScript.Close();
            IsOpen = false; //空いてない
        }
        else if ((IsEnemyEncounter == true || IsSkellEncounter == true || IsOkeEncounter == true)&&IsOpen==false)
        {
            StageScript.Open();
            IsOpen = true; //空いてる
        }
    }
}

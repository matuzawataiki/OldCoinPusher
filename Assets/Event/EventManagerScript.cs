using System.Collections;
using System.Collections.Generic;
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
    const int EnemyEncounterCoin = 5; //敵が出現するのに必要なコイン数
    const int SkellEncounterCoin = 7; //スケルトンが出現するのに必要なコイン数
    const int OkeEncounterCoin = 10; //上段に桶が出現するのに必要なコイン数
    const int JackPotActiveteCoban = 5; //ジャックポットが出現するのに必要な小判束数
    protected bool IsEnemyEncounter = false; //敵出現イベントがアクティブどうか
    protected bool IsSkellEncounter = false; //スケルトン出現イベントがアクティブどうか
    protected bool IsOkeEncounter = false; //上段に桶出現イベントがアクティブどうか
    protected bool IsJackPotActive = false; //ジャックポットイベントがアクティブどうか
    int coinCount = 0; //コインの数をカウントする変数
    int cobanCount = 0; //小判の数をカウントする変数
    [SerializeField]GameObject[] NowEvent=new GameObject[4]; //現在起きているイベントを格納する変数
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cobanCount%JackPotActiveteCoban==0 && IsJackPotActive == false)
        {
            GameObject gameObject = Instantiate(NowEvent[(int)EventType.JackPotActive], transform.position, Quaternion.identity);
            IsJackPotActive = true; //ジャックポットイベントがアクティブになる
        }
        if (coinCount % EnemyEncounterCoin ==0 && IsEnemyEncounter==false)
        {
            GameObject gameObject = Instantiate(NowEvent[(int)EventType.EnemyEncounter], transform.position, Quaternion.identity);
            IsEnemyEncounter = true; //敵出現イベントがアクティブになる
        }
        if (coinCount % SkellEncounterCoin == 0 && IsSkellEncounter==false)
        {
            GameObject gameObject = Instantiate(NowEvent[(int)EventType.SkellEncounter], transform.position, Quaternion.identity);
            IsSkellEncounter = true; //スケルトン出現イベントがアクティブになる
        }
        if (coinCount % OkeEncounterCoin==0 && IsOkeEncounter==false)
        {
            GameObject gameObject = Instantiate(NowEvent[(int)EventType.OkeEncounter], transform.position, Quaternion.identity);
            IsOkeEncounter = true; //上段に桶出現イベントがアクティブになる
        }
    }
}

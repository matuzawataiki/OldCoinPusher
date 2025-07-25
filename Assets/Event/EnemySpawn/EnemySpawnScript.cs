using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyType
{
    SnowSister = 0, //雪女
    Oni = 1, //鬼
    Carstronger = 2, //輸入者
    SkeltonBushi = 3, //どくろ武者
    numberOfEnemyType= 1 //敵の種類の数(実装でき次第数字加算してね)(今は雪女だけなので1で固定)。
}
//コインをある程度貯めたときランダムに敵を出現させるスクリプト
public class EnemySpawnScript : MonoBehaviour
{
    // 敵のプレハブを格納する変数(今は雪女だけなので1で固定)
    [SerializeField]GameObject[] enemyPrefab=new GameObject[(int)EnemyType.numberOfEnemyType];
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, (int)EnemyType.numberOfEnemyType);
        Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 15.0f, Random.Range(0.0f, 10.0f));
        GameObject EnemyObj = Instantiate(enemyPrefab[rand], pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

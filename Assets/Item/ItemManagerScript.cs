using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerScript : MonoBehaviour
{
    int Score = 0;
    int PrizeCount = 0; //景品の数。
    int CoinCount = 0; //コインの数。
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //スコアを追加する。
    protected void AddScore(int point)
    {
        Score += point;
    }

    //現在のスコアを取得する。
    protected int GetScore()
    {
        return Score;
    }

    //景品の数を追加する。
    protected void AddPrizeCount(int count)
    {
        PrizeCount += count;
    }
    //現在の景品の数を取得する。
    protected int GetPrizeCount()
    {
        return PrizeCount;
    }
    //コインの数を追加する。
    protected void AddCoinCount(int count)
    {
        CoinCount += count;
    }
    //現在のコインの数を取得する。
    protected int GetCoinCount()
    {
        return CoinCount;
    }
}

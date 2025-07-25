using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerScript : MonoBehaviour
{
    int Score = 0;
    int PrizeCount = 0; //�i�i�̐��B
    int CoinCount = 0; //�R�C���̐��B
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�X�R�A��ǉ�����B
    protected void AddScore(int point)
    {
        Score += point;
    }

    //���݂̃X�R�A���擾����B
    protected int GetScore()
    {
        return Score;
    }

    //�i�i�̐���ǉ�����B
    protected void AddPrizeCount(int count)
    {
        PrizeCount += count;
    }
    //���݂̌i�i�̐����擾����B
    protected int GetPrizeCount()
    {
        return PrizeCount;
    }
    //�R�C���̐���ǉ�����B
    protected void AddCoinCount(int count)
    {
        CoinCount += count;
    }
    //���݂̃R�C���̐����擾����B
    protected int GetCoinCount()
    {
        return CoinCount;
    }
}

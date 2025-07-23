using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject CoinScript; 
    int coinCount = 0;// コインの数をカウントする変数
    int cobanCount = 0; // 小判の数をカウントする変数
    int prezentCount = 0; // プレゼントの数をカウントする変数
                          
    void Start()
    {
        CoinScript=Instantiate(CoinScript, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

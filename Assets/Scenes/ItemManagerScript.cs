using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject CoinScript; 
    int coinCount = 0;// �R�C���̐����J�E���g����ϐ�
    int cobanCount = 0; // �����̐����J�E���g����ϐ�
    int prezentCount = 0; // �v���[���g�̐����J�E���g����ϐ�
                          
    void Start()
    {
        CoinScript=Instantiate(CoinScript, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//
enum PrizeType
{
    pig = 0,//�؂̒�����
    bag = 1,//�o�b�O
    Hat = 2,//�X�q
    HedPhone = 3,//�w�b�h�t�H��
    Crown = 4,//����
    numberOfPrizeType = 5 //�ܕi�̎�ނ̐�
}
public class SerectPrizeScript : MonoBehaviour
{
    [SerializeField] GameObject [] prize = new GameObject[(int)PrizeType.numberOfPrizeType];
    bool isGetTaru = false; // ������擾�������ǂ����̃t���O
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

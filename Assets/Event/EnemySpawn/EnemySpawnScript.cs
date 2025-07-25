using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyType
{
    SnowSister = 0, //�Ꮧ
    Oni = 1, //�S
    Carstronger = 2, //�A����
    SkeltonBushi = 3, //�ǂ��땐��
    numberOfEnemyType= 1 //�G�̎�ނ̐�(�����ł����搔�����Z���Ă�)(���͐Ꮧ�����Ȃ̂�1�ŌŒ�)�B
}
//�R�C����������x���߂��Ƃ������_���ɓG���o��������X�N���v�g
public class EnemySpawnScript : MonoBehaviour
{
    // �G�̃v���n�u���i�[����ϐ�(���͐Ꮧ�����Ȃ̂�1�ŌŒ�)
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

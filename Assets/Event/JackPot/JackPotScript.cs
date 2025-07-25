using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WhichJackPotItem
{
    Tawara = 0, //�U�B
    Coin = 1, //������
    numberOfJackPotItem //�W���b�N�|�b�g�̌i�i�̐�
}

public class JackPotScript : MonoBehaviour
{
    [SerializeField] GameObject[] JackPotStartDropItem=new GameObject [2]; //�W���b�N�|�b�g�̌i�i�̔z��
    int NowJackPotSceneIsTriggerToSpace = 0; //�X�y�[�X�L�[���������񐔂��J�E���g����ϐ�
    float JackPotTime = 10.0f; //�W���b�N�|�b�g�p������
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, (int)WhichJackPotItem.numberOfJackPotItem);
        Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 15.0f, Random.Range(-5.0f, 5.0f));
        GameObject JackPotObj = Instantiate(JackPotStartDropItem[rand], pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //�W���b�N�|�b�g�̎��Ԃ��J�E���g�_�E������B
        if (JackPotTime > 0.0f) {
            JackPotTime -= Time.deltaTime;
            //�X�y�[�X�L�[���������񐔂̃J�E���g
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NowJackPotSceneIsTriggerToSpace += 1;
            }
        } 
        else {
            NowJackPotSceneIsTriggerToSpace = 0; //�W���b�N�|�b�g�̎��Ԃ��I�������X�y�[�X�L�[���������񐔂����Z�b�g����B
        }
        
    }
}

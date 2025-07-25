using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EventType
{
    JackPotActive, //�W���b�N�|�b�g
    EnemyEncounter, //�G�o��
    SkellEncounter, //�X�P���g���o��
    OkeEncounter, //��i�ɉ��o��
}

//�C�x���g�o���̃}�l�[�W���[�X�N���v�g�B
public class EventManagerScript : MonoBehaviour
{
    const int EnemyEncounterCoin = 5; //�G���o������̂ɕK�v�ȃR�C����
    const int SkellEncounterCoin = 7; //�X�P���g�����o������̂ɕK�v�ȃR�C����
    const int OkeEncounterCoin = 10; //��i�ɉ����o������̂ɕK�v�ȃR�C����
    const int JackPotActiveteCoban = 5; //�W���b�N�|�b�g���o������̂ɕK�v�ȏ�������
    protected bool IsEnemyEncounter = false; //�G�o���C�x���g���A�N�e�B�u�ǂ���
    protected bool IsSkellEncounter = false; //�X�P���g���o���C�x���g���A�N�e�B�u�ǂ���
    protected bool IsOkeEncounter = false; //��i�ɉ��o���C�x���g���A�N�e�B�u�ǂ���
    protected bool IsJackPotActive = false; //�W���b�N�|�b�g�C�x���g���A�N�e�B�u�ǂ���
    int coinCount = 0; //�R�C���̐����J�E���g����ϐ�
    int cobanCount = 0; //�����̐����J�E���g����ϐ�
    [SerializeField]GameObject[] NowEvent=new GameObject[4]; //���݋N���Ă���C�x���g���i�[����ϐ�
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
            IsJackPotActive = true; //�W���b�N�|�b�g�C�x���g���A�N�e�B�u�ɂȂ�
        }
        if (coinCount % EnemyEncounterCoin ==0 && IsEnemyEncounter==false)
        {
            GameObject gameObject = Instantiate(NowEvent[(int)EventType.EnemyEncounter], transform.position, Quaternion.identity);
            IsEnemyEncounter = true; //�G�o���C�x���g���A�N�e�B�u�ɂȂ�
        }
        if (coinCount % SkellEncounterCoin == 0 && IsSkellEncounter==false)
        {
            GameObject gameObject = Instantiate(NowEvent[(int)EventType.SkellEncounter], transform.position, Quaternion.identity);
            IsSkellEncounter = true; //�X�P���g���o���C�x���g���A�N�e�B�u�ɂȂ�
        }
        if (coinCount % OkeEncounterCoin==0 && IsOkeEncounter==false)
        {
            GameObject gameObject = Instantiate(NowEvent[(int)EventType.OkeEncounter], transform.position, Quaternion.identity);
            IsOkeEncounter = true; //��i�ɉ��o���C�x���g���A�N�e�B�u�ɂȂ�
        }
    }
}

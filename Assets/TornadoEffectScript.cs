using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �g���l�[�h�̃G�t�F�N�g�𐧌䂷��N���X
/// </summary>
public class TornadoEffectScript : MonoBehaviour
{
    //�g���l�[�h�̃G�t�F�N�g
    public GameObject tornadoEffect;
    //�g���l�[�h�̃G�t�F�N�g�̃f�[�^���i�[����ϐ�
    private GameObject tornadoEffectData;

    //�g���l�[�h�̏�Ԃ��Ǘ�����񋓌^
    enum TornadoState
    {
        None,// �������Ȃ�
        Move // �ړ����
    }

    //�g���l�[�h�̈ړ���Ԃ��Ǘ�����񋓌^
    enum TornadoMoveDirectionState
    {
        Left, //�E�Ɉړ�
        Right //���Ɉړ�
    }

    //�g���l�[�h�̏�Ԃ��Ǘ�����ϐ�
    TornadoState tornadoState = TornadoState.None;

    //�g���l�[�h�̈ړ���Ԃ��Ǘ�����ϐ�
    TornadoMoveDirectionState tornadoMoveDirectionState = TornadoMoveDirectionState.Left;

    //�g���l�[�h�̐�������
    float tornadoLifeTime = 0.0f;
    
    //�g���l�[�h�����ł��鎞��
    float tornadoDestroyTime = 4.0f;

    //�g���l�[�h�𐶐����Ă��邩�ǂ������Ǘ�����t���O
    bool isTornadoActive = false;

    // Start is called before the first frame update
    void Start()
    {
        tornadoEffectData = tornadoEffect;
    }

    //�g���l�[�h�̈ړ�����
    void TornadoMove()
    {
        if (tornadoMoveDirectionState == TornadoMoveDirectionState.Left)
        {
            //�g���l�[�h�����Ɉړ�������
            tornadoEffect.transform.Translate(Vector3.left * 0.5f * Time.deltaTime, Space.World);
        }
        else if (tornadoMoveDirectionState == TornadoMoveDirectionState.Right)
        {
            //�g���l�[�h���E�Ɉړ�������
            tornadoEffect.transform.Translate(Vector3.right * 0.5f * Time.deltaTime, Space.World);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�g���l�[�h���A�N�e�B�u�ȏꍇ�̏���
        if (isTornadoActive)
        {
            //�g���l�[�h�̏�Ԃ��ړ���Ԃ̂Ƃ�
            if(tornadoState == TornadoState.Move)
            {
                TornadoMove();//�g���l�[�h�̈ړ�����
            }

            //�g���l�[�h�̐������Ԃ̍X�V
            tornadoLifeTime += Time.deltaTime;

            //�g���l�[�h�̐������Ԃ�0�b�ɂȂ�����g���l�[�h�����ł���
            if (tornadoLifeTime >= tornadoDestroyTime)
            {
                //�g���l�[�h�̃G�t�F�N�g���폜����
                Destroy(tornadoEffect);

                //�g���l�[�h�̃G�t�F�N�g��������Ԃɖ߂�
                tornadoEffect = tornadoEffectData;

                //�g���l�[�h�̐������Ԃ����Z�b�g����
                tornadoLifeTime = 0.0f;

                //�g���l�[�h�̏�Ԃ����Z�b�g����
                isTornadoActive = false;
            }
        }
        // �g���l�[�h���A�N�e�B�u�łȂ��ꍇ�̏���
        else
        {
            //�f�o�b�O�p�̃g���l�[�h����
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //�g���l�[�h�̃G�t�F�N�g�𐶐�����
                tornadoEffect = Instantiate(tornadoEffect, tornadoEffect.transform.position, Quaternion.identity);

                //�g���l�[�h�̃G�t�F�N�g�̃X�P�[���𒲐�����
                Vector3 tornadoEffectScale = tornadoEffect.transform.localScale;
                tornadoEffectScale *= 1.5f;
                tornadoEffect.transform.localScale = tornadoEffectScale;

                //�g���l�[�h�̏�Ԃ������_���ɐݒ肷��
                tornadoState = (TornadoState)Random.Range(0, 2);

                //�g���l�[�h�̏�Ԃ��ړ���Ԃ̂Ƃ�
                if (tornadoState == TornadoState.Move)
                {
                    //�g���l�[�h�̈ړ���Ԃ������_���ɐݒ肷��
                    tornadoMoveDirectionState = (TornadoMoveDirectionState)Random.Range(0, 2);
                }

                //�g���l�[�h�̏�Ԃ��A�N�e�B�u�ɂ���
                isTornadoActive = true;
            }
        }
    }
}

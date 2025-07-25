using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �t���[�Y�̃G�t�F�N�g�𐧌䂷��N���X
/// </summary>
public class FreezeEffectScript : MonoBehaviour
{
    //�t���[�Y�̃G�t�F�N�g
    public GameObject freezeEffect;
    //�t���[�Y�̃G�t�F�N�g�̃f�[�^���i�[����ϐ�
    private GameObject freezeEffectData;

    //�t���[�Y�̐�������
    float freezeLifeTime = 0.0f;

    //�t���[�Y�����ł��鎞��
    float freezeDestroyTime = 2.0f;

    //�t���[�Y�𐶐����Ă��邩�ǂ������Ǘ�����t���O
    bool isFreezeActive = false;

    //�t���[�Y�𐶐����邩�ǂ������Ǘ�����t���O
    bool isFreezeSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        freezeEffectData = freezeEffect;
    }

    //�t���[�Y�������Ă���H
    public bool IsActive()
    {
        return isFreezeActive;
    }

    //�t���[�Y�̐���
    public void Spawn()
    {
        isFreezeSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFreezeActive)
        {
            //�t���[�Y�̐������Ԃ̍X�V
            freezeLifeTime += Time.deltaTime;

            //�g���l�[�h�̐������Ԃ�0�b�ɂȂ�����t���[�Y�����ł���
            if (freezeLifeTime >= freezeDestroyTime)
            {
                //�t���[�Y�̃G�t�F�N�g���폜����
                Destroy(freezeEffect);

                //�t���[�Y�̃G�t�F�N�g��������Ԃɖ߂�
                freezeEffect = freezeEffectData;

                //�t���[�Y�̐������Ԃ����Z�b�g����
                freezeLifeTime = 0.0f;

                //�t���[�Y�̏�Ԃ����Z�b�g����
                isFreezeActive = false;
            }
        }
        else
        {
            //�t���[�Y����
            if (isFreezeSpawn)
            {
                Vector3 freezeEffectPos = transform.position;
                freezeEffectPos.z += 2.5f;

                //�t���[�Y�G�t�F�N�g�𐶐�
                freezeEffect = Instantiate(freezeEffect, freezeEffectPos, freezeEffect.transform.rotation);

                //�t���[�Y�̏�Ԃ��A�N�e�B�u�ɂ���
                isFreezeActive = true;

                //�t���[�Y�����ł���
                isFreezeSpawn = false;
            }
        }
    }
}

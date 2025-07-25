using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�l�~�[�S�N���X
/// </summary>
public class OgreScript : MonoBehaviour
{
    //�g���l�[�h�p�̃X�N���v�g
    TornadoEffectScript tornadoEffectScript;

    //�S�̈ړ������̏�Ԃ��Ǘ�����񋓌^
    enum OgreMoveDirectionState
    {
        Left,  // ���Ɉړ�
        Right, // �E�Ɉړ�
    }

    //�S�̈ړ������̏�Ԃ�ێ�����ϐ�
    OgreMoveDirectionState moveDirectionState = OgreMoveDirectionState.Left;

    //�S�̈ړ����x
    float moveSpeed = 10.0f;

    //�S�̈ړ�����ʒu�̏��
    private float moveLimit = 25.0f;

    //�S�̓����ҋ@���鎞��
    float ogreActionWaitTime = 0.0f;

    //�S�̓���̊Ԋu����
    float ogreActionInterval = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�S�̈ړ������̏�Ԃ������_���ɐݒ�
        moveDirectionState = (OgreMoveDirectionState)Random.Range(0, 2);

        //�g���l�[�h�p�̃X�N���v�g�擾
        tornadoEffectScript = this.GetComponent<TornadoEffectScript>();

        //�S�̓���̊Ԋu���Ԃ������_���ɐݒ�
        ogreActionInterval = Random.Range(4, 7);
    }

    //�S�̈ړ�����
    void Move()
    {
        //�S�̈ړ������ɉ����Ĉړ��������s��
        switch (moveDirectionState)
        {
            case OgreMoveDirectionState.Left:
                transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                break;
            case OgreMoveDirectionState.Right:
                transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                break;
        }

        //��ʊO�ɏo���甽�Α��Ɉړ�����
        if (transform.position.x < -moveLimit)
        {
            moveDirectionState = OgreMoveDirectionState.Right;
        }
        else if (transform.position.x > moveLimit)
        {
            moveDirectionState = OgreMoveDirectionState.Left;
        }
    }

    //�S�̓���
    void Action()
    {
        //�g���l�[�h�𐶐����Ă��Ȃ��Ƃ��ɏ�������
        if (!tornadoEffectScript.IsActive())
        {
            ogreActionWaitTime += Time.deltaTime;

            if (ogreActionWaitTime >= ogreActionInterval)
            {
                tornadoEffectScript.Spawn();
                ogreActionInterval = Random.Range(4, 7);
                ogreActionWaitTime = 0.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�S�̈ړ�����

        Action();//�S�̓���
    }
}

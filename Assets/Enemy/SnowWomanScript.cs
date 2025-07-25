using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�l�~�[�Ꮧ�N���X
/// </summary>
public class SnowWomanScript : MonoBehaviour
{
    //�t���[�Y�p�̃X�N���v�g
    FreezeEffectScript freezeEffectScript;

    //�Ꮧ�̈ړ������̏�Ԃ��Ǘ�����񋓌^
    enum SnowWomanMoveDirectionState
    {
        Left,  // ���Ɉړ�
        Right, // �E�Ɉړ�
    }

    //�Ꮧ�̈ړ������̏�Ԃ�ێ�����ϐ�
    SnowWomanMoveDirectionState moveDirectionState = SnowWomanMoveDirectionState.Left;

    //�Ꮧ�̈ړ����x
    float moveSpeed = 3.0f;

    //�Ꮧ�̈ړ�����ʒu�̏��
    private float moveLimit = 25.0f;

    //�Ꮧ�̈ړ���ҋ@���鎞��
    float snowWomanMoveWaitTime = 0.0f;

    //�Ꮧ�̈ړ��̊Ԋu����
    float snowWomanMoveInterval = 2.0f;

    //�Ꮧ�̃C�[�W���O�O�̈ʒu
    Vector3 snowWomanPositionBeforeEasing;

    //�Ꮧ�̃C�[�W���O��̈ʒu
    Vector3 snowWomanPositionAfterEasing;

    //�Ꮧ�̃C�[�W���O�̈ʒu�̐ݒ�ł�����?
    bool isSetSnowWomanPositionEasing = false;

    //�Ꮧ�͈ړ�������?
    bool isSnowWomanMove = false;

    //�Ꮧ�̈ړ��p�̃C�[�W���O�̊���
    float snowWomanMoveEasingTime = 0.0f;

    //�Ꮧ�̓����ҋ@���鎞��
    float snowWomanActionWaitTime = 0.0f;

    //�Ꮧ�̓���̊Ԋu����
    float snowWomanActionInterval = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�Ꮧ�̈ړ������̏�Ԃ������_���ɐݒ�
        moveDirectionState=(SnowWomanMoveDirectionState)Random.Range(0, 2);

        //�t���[�Y�p�̃X�N���v�g�擾
        freezeEffectScript = this.GetComponent<FreezeEffectScript>();

        //�S�̓���̊Ԋu���Ԃ������_���ɐݒ�
        snowWomanActionInterval = Random.Range(4, 7);
    }

    //�S�̈ړ�����
    void Move()
    {
        if(isSnowWomanMove)
        {
            snowWomanMoveWaitTime += Time.deltaTime;

            if(snowWomanMoveWaitTime>=snowWomanMoveInterval)
            {
                isSnowWomanMove = false;
                isSetSnowWomanPositionEasing = false;
                snowWomanMoveWaitTime = 0.0f;
            }
        }
        else
        {
            if (!isSetSnowWomanPositionEasing)
            {
                SetPositionEasing();
            }
            else
            {
                PositionEasing();
            }
        }
    }

    //�ʒu�̃C�[�W���O�ݒ�
    void SetPositionEasing()
    {
        snowWomanPositionBeforeEasing = transform.position;
        snowWomanPositionAfterEasing = transform.position;

        //��ʊO�ɏo���甽�Α��Ɉړ�����
        if (transform.position.x <= -moveLimit)
        {
            moveDirectionState = SnowWomanMoveDirectionState.Right;
        }
        else if (transform.position.x >= moveLimit)
        {
            moveDirectionState = SnowWomanMoveDirectionState.Left;
        }

        switch (moveDirectionState)
        {
            case SnowWomanMoveDirectionState.Left:
                snowWomanPositionAfterEasing.x = transform.position.x - 5.0f;
                break;
            case SnowWomanMoveDirectionState.Right:
                snowWomanPositionAfterEasing.x = transform.position.x + 5.0f;
                break;
        }

        snowWomanMoveEasingTime = 0.0f;
        isSetSnowWomanPositionEasing = true;
    }

    //�ʒu�̃C�[�W���O����
    void PositionEasing()
    {
        snowWomanMoveEasingTime += moveSpeed * Time.deltaTime;

        if(snowWomanMoveEasingTime>1.0f)
        {
            snowWomanMoveEasingTime = 1.0f;
            isSnowWomanMove = true;
        }

        transform.position = Vector3.Lerp
        (
            snowWomanPositionBeforeEasing, 
            snowWomanPositionAfterEasing, 
            snowWomanMoveEasingTime
        );
    }

    //�S�̓���
    void Action()
    {
        //�g���l�[�h�𐶐����Ă��Ȃ��Ƃ��ɏ�������
        if (!freezeEffectScript.IsActive())
        {
            snowWomanActionWaitTime += Time.deltaTime;

            if (snowWomanActionWaitTime >= snowWomanActionInterval)
            {
                freezeEffectScript.Spawn();
                snowWomanActionInterval = Random.Range(4, 7);
                snowWomanActionWaitTime = 0.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�Ꮧ�̈ړ�����

        Action();//�Ꮧ�̓���
    }
}

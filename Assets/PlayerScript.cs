using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C���[�N���X
/// </summary>
public class PlayerScript : MonoBehaviour
{
    //�ړ��p�̕ϐ��ꗗ
    //�v���C���[�̈ړ����x
    float moveSpeed = 5.0f;


    //��]�p�̕ϐ��ꗗ
    //�v���C���[�̉�]���x
    float rotationSpeed = 45.0f;

    //�v���C���[�̌��݂�X���̊p�x���i�[����ϐ�
    private float currentRotationX = 0.0f;

    //�v���C���[�̌��݂�Y���̊p�x���i�[����ϐ�
    private float currentRotationY = 0.0f;


    //�R�C�����˗p�̕ϐ��ꗗ
    //�R�C���I�u�W�F�N�g���i�[����ϐ�
    public GameObject coinObject;

    //�R�C���̔��ˑ��x
    float coinShotSpeed = 500.0f;

    //�R�C���𔭎˂𐧌�����t���O
    bool shotCoinLimitFlag = false;

    //�����ŃR�C���𔭎˂���t���O
    bool autoShotCoinFlag = false;

    //�R�C���𔭎˂ł���Ԋu�i�b�j
    float shotCoinInterval = 0.3f;

    //�R�C���𔭎˂ł���Ԋu�̃^�C�}�[
    float shotCoinTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�v���C���[�̈ړ�����
    void Move()
    {
        //�E�ړ�
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        //���ړ�
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
    }

    //�v���C���[�̉�]����
    void Rotation()
    {
        //���]
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-rotationSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        //����]
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        MoveRotationXLimit();//�v���C���[��X���̉�]�𐧌����鏈��

        //����]
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f, Space.World);
        }

        //�E��]
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f, Space.World);
        }

        MoveRotationYLimit();//�v���C���[��Y���̉�]�𐧌����鏈��
    }

    //�v���C���[��X���̉�]�𐧌����鏈��
    void MoveRotationXLimit()
    {
        //�v���C���[�̌��݂�X���̊p�x���擾
        currentRotationX = transform.rotation.eulerAngles.x;
        //�p�x��-180�`180�͈͓̔��ɂȂ�悤�ɕ␳
        if (currentRotationX > 180.0f)
        {
            currentRotationX -= 360.0f;
        }

        //X���̉�]�𐧌�
        currentRotationX = Mathf.Clamp(currentRotationX, -30.0f, 30.0f);
        transform.localEulerAngles = new Vector3(currentRotationX, transform.localEulerAngles.y, 0.0f);
    }

    //�v���C���[��Y���̉�]�𐧌����鏈��
    void MoveRotationYLimit()
    {
        //�v���C���[�̌��݂�Y���̊p�x���擾
        currentRotationY = transform.rotation.eulerAngles.y;
        //�p�x��-180�`180�͈͓̔��ɂȂ�悤�ɕ␳
        if (currentRotationY > 180.0f)
        {
            currentRotationY -= 360.0f;
        }

        //Y���̉�]�𐧌�
        currentRotationY = Mathf.Clamp(currentRotationY, -30.0f, 30.0f);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentRotationY, 0.0f);
    }

    //�R�C���𔭎˂��鏈��
    void ShotCoin()
    {
        //�蓮�ŃR�C���𔭎˂��Ă���Ƃ�
        if (!autoShotCoinFlag)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                //�����ŃR�C���𔭎˂���悤�ɐ؂�ւ���
                autoShotCoinFlag = true;
            }
        }
        //�����ŃR�C���𔭎˂��Ă���Ƃ�
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                //�蓮�ŃR�C���𔭎˂���悤�ɐ؂�ւ���
                autoShotCoinFlag = false;
            }
        }

        //�R�C���̔��˂𐧌�����Ă��Ȃ��ꍇ�́A�R�C���𔭎˂ł���
        if (!shotCoinLimitFlag)
        {
            if (Input.GetKey(KeyCode.Space) || autoShotCoinFlag)
            {
                //�R�C���I�u�W�F�N�g�𐶐����鏈��
                CreateCoinObject();

                //�R�C���̔��˂𐧌�����
                shotCoinLimitFlag = true;
            }
        }
        //�R�C���̔��˂𐧌�����Ă���ꍇ�́A�R�C���̔��˂𐧌�����
        else
        {
            //�R�C���̔��˂𐧌����鎞�Ԃ̍X�V
            shotCoinTimer += Time.deltaTime;

            //�R�C���̔��˂𐧌����鎞�Ԃ��o�߂����ꍇ�A�R�C���̔��˂𐧌�����������
            if (shotCoinTimer >= shotCoinInterval)
            {
                shotCoinLimitFlag = false;
                shotCoinTimer = 0.0f;
            }
        }
    }

    //�R�C���I�u�W�F�N�g�𐶐����鏈��
    void CreateCoinObject()
    {
        //�R�C���̔��ˈʒu���v���C���[�̑O���ɐݒ�
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);

        //�R�C���I�u�W�F�N�g�𐶐����A�v���C���[�̑O���ɔ��˂���
        GameObject coin = Instantiate(coinObject, playerPos, Quaternion.identity);

        //�R�C����Rigidbody�R���|�[�l���g�̎擾
        Rigidbody coinRigidbody = coin.GetComponent<Rigidbody>();

        //�R�C����Rigidbody�ɗ͂������āA�R�C����O���ɔ��˂���
        coinRigidbody.AddForce(transform.forward * coinShotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�v���C���[�̈ړ�����

        Rotation();//�v���C���[�̉�]����

        ShotCoin();//�R�C���𔭎˂��鏈��
    }
}

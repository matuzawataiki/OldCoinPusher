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
    float moveSpeed = 10.0f;

    //�v���C���[�̌��݂�X���̈ʒu���i�[����ϐ�
    private float currentPositionX = 0.0f;

    //�v���C���[�̈ړ���������
    public float moveLimit = 15.0f;

    //��]�p�̕ϐ��ꗗ
    //�v���C���[�̉�]���x
    float rotationSpeed = 45.0f;

    //�v���C���[�̌��݂�X���̊p�x���i�[����ϐ�
    private float currentRotationX = 0.0f;

    //�v���C���[�̌��݂�Y���̊p�x���i�[����ϐ�
    private float currentRotationY = 0.0f;

    //�v���C���[�̉�]�����p�x
    public float rotationLimit = 30.0f;

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

        MovePositionXLimit();//�v���C���[��X���̈ړ��𐧌����鏈��
    }

    //�v���C���[��X���̈ړ��𐧌����鏈��
    void MovePositionXLimit()
    {
        //�v���C���[�̌��݂�X���̈ʒu���擾
        currentPositionX = transform.position.x;

        //X���̈ړ��𐧌�
        currentPositionX = Mathf.Clamp(currentPositionX, -moveLimit, moveLimit);
        transform.position = new Vector3(currentPositionX, transform.position.y, transform.position.z);
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
        currentRotationX = Mathf.Clamp(currentRotationX, -rotationLimit, rotationLimit);
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
        currentRotationY = Mathf.Clamp(currentRotationY, -rotationLimit, rotationLimit);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentRotationY, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�v���C���[�̈ړ�����

        Rotation();//�v���C���[�̉�]����
    }
}

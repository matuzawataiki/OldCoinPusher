using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e���̊��N���X
public class ItemScript : MonoBehaviour
{
    // �A�C�e���̍��W��ݒ肷��
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    // �A�C�e���̉�]��ݒ肷��
    public void SetRotation(Quaternion rot)
    {
        transform.rotation = rot;
    }

    // �A�C�e���̃X�P�[����ݒ肷��
    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    // �A�C�e���̈ʒu���擾����
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    // �A�C�e���̉�]���擾����
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    // �A�C�e���̃X�P�[�����擾����
    public Vector3 GetScale()
    {
        return transform.localScale;
    }
    
    public Vector3 SetPower(Vector3 power)
    {
        // �A�C�e���ɗ͂�������
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(power);
        }
        return power;
    }

}

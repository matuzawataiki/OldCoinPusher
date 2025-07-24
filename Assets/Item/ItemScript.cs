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

  
    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

  
    public Vector3 GetScale()
    {
        return transform.localScale;
    }

    public Vector3 SetPower(Vector3 power)
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(power);
        }
        return power;
    }

}

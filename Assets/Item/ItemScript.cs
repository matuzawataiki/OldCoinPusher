using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの基底クラス
public class ItemScript : ItemManagerScript
{
    [SerializeField] int Point;//景品のポイント。

    //座標の設定
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    //回転の設定。
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

    public bool SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        return isActive;
    }
}

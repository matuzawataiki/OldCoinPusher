using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの基底クラス
public class ItemScript : MonoBehaviour
{
    // アイテムの座標を設定する
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    // アイテムの回転を設定する
    public void SetRotation(Quaternion rot)
    {
        transform.rotation = rot;
    }

    // アイテムのスケールを設定する
    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    // アイテムの位置を取得する
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    // アイテムの回転を取得する
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    // アイテムのスケールを取得する
    public Vector3 GetScale()
    {
        return transform.localScale;
    }
    
    public Vector3 SetPower(Vector3 power)
    {
        // アイテムに力を加える
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(power);
        }
        return power;
    }

}

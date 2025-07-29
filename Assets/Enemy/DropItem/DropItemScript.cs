using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ドロップするアイテムの挙動を制御するクラス
/// </summary>
public class DropItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerGround")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

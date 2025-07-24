using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PusherScript : MonoBehaviour
{
    bool m_isMove = false;
    bool m_moveDirection = false;
    float t = 0.0f;
    Vector3 StartPosition = new Vector3(0.0f, 0.0f, 20.0f);
    Vector3 EndPosition = new Vector3(0.0f, 0.0f, 15.0f);
    [SerializeField] float m_moveSpeed = 0.001f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isMove)
        {
            return;
        }

        if (m_moveDirection)
        {
            t += m_moveSpeed;
        }
        else
        {
            t -= m_moveSpeed;
        }

        float zLerp = Vector3.Lerp(StartPosition, EndPosition, t).z;
        Vector3 position = transform.position;
        position.z = zLerp;
        transform.position = position;

        if(t > 1.0f)
        {
            m_moveDirection = false;
        }
        if (t < 0.0f)
        {
            m_moveDirection = true;
        }
    }

    public void OnMove()
    {
        m_isMove = true;
    }
    public void SetRatio(float ratio)
    {
        if (ratio <= 1.0f)
        {
            t = ratio;
        }
        else
        {
            t = 1.0f - (ratio - 1.0f);
            m_moveDirection = true;
        }
    }
}

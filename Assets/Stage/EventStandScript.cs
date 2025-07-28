using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStandScript : MonoBehaviour
{
    bool m_isMove = false;
    bool m_moveDirection = false;
    float t = 0.0f;
    Vector3 StartPosition = new Vector3(0.0f, 0.0f, 11.34f);
    Vector3 EndPosition = new Vector3(0.0f, 0.0f, 24.0f);
    [SerializeField] float m_moveSpeed = 0.001f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isMove)
        {
            return;
        }

        float zLerp = Vector3.Lerp(StartPosition, EndPosition, t).z;
        Debug.Log(t);
        Debug.Log(zLerp);
        rb.MovePosition(new Vector3(
            transform.position.x,
            transform.position.y,
            zLerp
        ));

        if (m_moveDirection)
        {
            t += m_moveSpeed;
        }
        else
        {
            t -= m_moveSpeed;
        }

        if (t < 0.0f || t > 1.0f) {
            m_isMove = false;
        }
    }

    public void Open()
    {
        t = 0.0f;
        m_isMove = true;
        m_moveDirection = true;
    }

    public void Close()
    {
        t = 1.0f;
        m_isMove = true;
        m_moveDirection = false;
    }
}

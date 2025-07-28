using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PusherManagerScript : MonoBehaviour
{
    [SerializeField] GameObject m_pusherBox;
    GameObject[] m_pushers = new GameObject[8];
    PusherScript[] m_pusherScripts = new PusherScript[8];

    [SerializeField] GameObject m_eventStandBox;
    GameObject[] m_eventStands = new GameObject[5];
    EventStandScript[] m_eventStandScripts = new EventStandScript[5];

    bool m_isOpen = false;
    bool m_isClose = false;

    int m_countTime = 0;
    int m_count = 0;

    Vector3[] PusherPosition = new Vector3[8]
    {
        new Vector3(22.4f,1.0f,20.0f),
        new Vector3(16.0f,1.0f,20.0f),
        new Vector3(9.6f,1.0f,20.0f),
        new Vector3(3.2f,1.0f,20.0f),
        new Vector3(-3.2f,1.0f,20.0f),
        new Vector3(-9.6f,1.0f,20.0f),
        new Vector3(-16.0f,1.0f,20.0f),
        new Vector3(-22.4f,1.0f,20.0f)
    };

    Vector3[] EventStandPosition = new Vector3[5]
    {
        new Vector3(24.8f,9.0f,11.34f),
        new Vector3(12.4f,9.0f,11.34f),
        new Vector3(0.0f,9.0f,11.34f),
        new Vector3(-12.4f,9.0f,11.34f),
        new Vector3(-24.8f,9.0f,11.34f),
    };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_pushers.Length; i++)
        {
            m_pushers[i] = GameObject.Instantiate(m_pusherBox);
            m_pushers[i].transform.position = PusherPosition[i];
            m_pusherScripts[i] = m_pushers[i].GetComponent<PusherScript>();
            m_pusherScripts[i].OnMove();
            m_pusherScripts[i].SetRatio(0.25f * (i + 1));
        }

        for(int i = 0;i < m_eventStands.Length; i++)
        {
            m_eventStands[i] = GameObject.Instantiate(m_eventStandBox);
            m_eventStands[i].transform.position = EventStandPosition[i];
            m_eventStandScripts[i] = m_eventStands[i].GetComponent<EventStandScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isOpen)
        {
            OpenEventStage();
        }

        if (m_isClose)
        {
            CloseEventStage();
        }

        if (Input.GetKeyUp(KeyCode.K)) {
            Open();
        }
        if (Input.GetKeyUp(KeyCode.J)) { 
            Close();
        }
    }

    public void Open()
    {
        m_isOpen = true;
        m_count = 0;
        m_countTime = 0;
    }
    public void Close()
    {
        m_count = 0;
        m_countTime = 0;
        m_isClose = true;
    }


    private void OpenEventStage()
    {
        m_countTime++;

        if(m_countTime >= 120)
        {
            m_countTime = 0;
            m_eventStandScripts[m_count].Open();
            m_count++;
        }

        if(m_count >= m_eventStands.Length)
        {
            m_isOpen = false;
        }
    }
    private void CloseEventStage()
    {
        m_countTime++;

        if (m_countTime >= 300)
        {
            m_countTime = 0;
            m_eventStandScripts[m_count].Close();
            m_count++;
        }

        if (m_count >= m_eventStands.Length)
        {
            m_isClose = false;
        }
    }
}

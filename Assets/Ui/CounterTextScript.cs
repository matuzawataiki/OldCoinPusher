using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CounterTextScript : MonoBehaviour
{
    TextMeshProUGUI m_text;
    int m_counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = m_counter.ToString();
    }

    public void SetCoinCount(int counter)
    {
        m_counter = counter;
    }
}

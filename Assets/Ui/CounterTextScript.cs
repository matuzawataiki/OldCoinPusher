using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CounterTextScript : MonoBehaviour
{
    [SerializeField] EnCounterType counterType;
    [SerializeField] GameObject SaveDataObject;
    SaveData m_saveData;
    TextMeshProUGUI m_text;
    public enum EnCounterType
    {
        enCoin,
        enJackpot,
        enItem
    }
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        m_saveData = SaveDataObject.GetComponent<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        float counter = 0.0f;
        switch (counterType)
        {
            case EnCounterType.enCoin:
                counter = m_saveData.GetCoin();
                break;

            case EnCounterType.enJackpot:
                counter = m_saveData.GetJackpot();
                break;

            case EnCounterType.enItem:
                counter = m_saveData.GetItem();
                break;
        }
        m_text.text = counter.ToString();
    }
}

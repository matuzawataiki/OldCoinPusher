using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UI;

public class CounterTextScript : MonoBehaviour
{
    [SerializeField] EnCounterType counterType;
    [SerializeField] int Number;
    [SerializeField] GameObject SaveDataObject;
    SaveData m_saveData;
    MenuData m_menuData;
    Text m_text;
    public enum EnCounterType
    {
        enCoin,
        enJackpot,
        enItem,
        enItemList,
        enMonsterRecord,
        enUpgrade,
        enStore
    }
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
        m_saveData = SaveDataObject.GetComponent<SaveData>();
        m_menuData = SaveDataObject.GetComponent<MenuData>();
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
            case EnCounterType.enItemList:
                counter = m_menuData.GetItemNum(Number - 1);
                break;
            case EnCounterType.enMonsterRecord:
                counter = m_menuData.GetMonsterRecord(Number - 1);
                break;
            case EnCounterType.enUpgrade:
                counter = m_menuData.GetUpgrade(Number - 1);
                break;
            case EnCounterType.enStore:
                counter = m_menuData.GetStore(Number - 1);
                break;
        }
        m_text.text = counter.ToString();
    }
}

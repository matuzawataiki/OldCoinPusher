using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreTextScript : MonoBehaviour
{
    [SerializeField] int MaxLevel = 0;
    [SerializeField] int Number = 0;
    [SerializeField] GameObject SaveDataObject;
    MenuData m_menuData;
    TextMeshProUGUI m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        m_menuData = SaveDataObject.GetComponent<MenuData>();
    }

    // Update is called once per frame
    void Update()
    {
        int level = m_menuData.GetStore(Number);
        string text = level.ToString() + " / " + MaxLevel.ToString();
        m_text.text = text;
    }
}

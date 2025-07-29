using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreLevelTextScript : MonoBehaviour
{
    [SerializeField] public int MaxLevel = 0;
    [SerializeField] public int Number = 0;
    [SerializeField] GameObject SaveDataObject;
    MenuData m_menuData;
    Text m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
        m_menuData = SaveDataObject.GetComponent<MenuData>();
    }

    // Update is called once per frame
    void Update()
    {
        int level = m_menuData.GetStore(Number - 1);
        string text = level.ToString() + " / " + MaxLevel.ToString();
        m_text.text = text;
    }
}

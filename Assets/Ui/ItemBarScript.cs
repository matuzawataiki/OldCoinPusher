using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBarScript : MonoBehaviour
{
    [SerializeField] float m_itemPoint = 0.0f;
    [SerializeField] const float MaxItemPint = 10.0f;
    [SerializeField] GameObject m_saveData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_itemPoint >= MaxItemPint)
        {
            AddItem();
            m_itemPoint -= MaxItemPint;
        }

        GetComponent<Slider>().value = m_itemPoint;
    }

    public void AddItemPoint(float itemPoint)
    {
        m_itemPoint += itemPoint;
    }

    private void AddItem()
    {
        SaveData saveData = m_saveData.AddComponent<SaveData>();
        saveData.AddItem(1);
    }
}

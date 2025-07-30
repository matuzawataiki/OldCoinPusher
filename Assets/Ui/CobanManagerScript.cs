using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobanManagerScript : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects = new GameObject[5];
    [SerializeField] GameObject SaveDataObject;
    SaveData m_saveData;
    // Start is called before the first frame update
    void Start()
    {
        m_saveData = SaveDataObject.GetComponent<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_saveData.GetCoban(); i++) {
            gameObjects[i].SetActive(true);
        }
        for (int i = 4; i >= m_saveData.GetCoban(); i--)
        {
            gameObjects[i].SetActive(false);
        }
        if (m_saveData.GetCoban() == 5) { 
            m_saveData.SetCoban(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueTextScript : MonoBehaviour
{
    [SerializeField] public int m_value = 0;
    Text m_text;
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
        m_text.text = m_value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

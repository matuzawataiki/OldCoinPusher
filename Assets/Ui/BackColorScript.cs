using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackColorScript : MonoBehaviour
{
    [SerializeField] int Offset;
    [SerializeField] GameObject Text;
    RectTransform m_spriteRectTransform;
    RectTransform m_textRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        m_textRectTransform = Text.GetComponent<RectTransform>();
        m_spriteRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        float spriteSize = m_textRectTransform.sizeDelta.x;
        spriteSize += Offset;
        m_spriteRectTransform.sizeDelta = new Vector2(spriteSize, m_spriteRectTransform.sizeDelta.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{
    [SerializeField] GameObject MenuObject;
    [SerializeField] GameObject InMenuBackSprite;
    [SerializeField] GameObject[] InMenuObject = new GameObject[4];
    public enum EnSelectButton
    {
        enBackGameButton,
        enItemListButton,
        enMonsterRecordButton,
        enUpgradeButton,
        enStoreButton,
        enGuideButton,
        enSettingButton,
        enExitButton
    }
    public enum EnMenuState
    {
        enNone,
        enMenu,
        enInMenu
    } 
    EnMenuState m_enMenuState = EnMenuState.enNone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_enMenuState)
        {
            case EnMenuState.enNone:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    m_enMenuState = EnMenuState.enMenu;
                    MenuObject.SetActive(true);
                }
                break;
            case EnMenuState.enMenu:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    m_enMenuState = EnMenuState.enNone;
                    MenuObject.SetActive(false);
                }
                break;
            case EnMenuState.enInMenu:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    m_enMenuState = EnMenuState.enMenu;
                    MenuObject.SetActive(true);
                    InMenuBackSprite.SetActive(false);
                    for (int i = 0; i < InMenuObject.Length; i++) { 
                        InMenuObject[i].SetActive(false);
                    }
                }
                break;
        }
    }

    public void OnMenuButton(EnSelectButton button)
    {
        switch (button)
        {
            case EnSelectButton.enBackGameButton:
                m_enMenuState = EnMenuState.enNone;
                MenuObject.SetActive(false);
                break;

            case EnSelectButton.enItemListButton:
                m_enMenuState = EnMenuState.enInMenu;
                MenuObject.SetActive(false);
                InMenuObject[0].SetActive(true);
                InMenuBackSprite.SetActive(true);
                break;

            case EnSelectButton.enMonsterRecordButton:
                m_enMenuState = EnMenuState.enInMenu;
                MenuObject.SetActive(false);
                InMenuObject[1].SetActive(true);
                InMenuBackSprite.SetActive(true);
                break;

            case EnSelectButton.enUpgradeButton:
                m_enMenuState = EnMenuState.enInMenu;
                MenuObject.SetActive(false);
                InMenuObject[2].SetActive(true);
                InMenuBackSprite.SetActive(true);
                break;

            case EnSelectButton.enStoreButton:
                m_enMenuState = EnMenuState.enInMenu;
                MenuObject.SetActive(false);
                InMenuObject[3].SetActive(true);
                InMenuBackSprite.SetActive(true);
                break;

            case EnSelectButton.enGuideButton:

                break;

            case EnSelectButton.enSettingButton:
                break;

            case EnSelectButton.enExitButton:
                break;
        }
    }
}

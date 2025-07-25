using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{
    [SerializeField] GameObject MenuObject;
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
                break;

            case EnSelectButton.enMonsterRecordButton:
                break;

            case EnSelectButton.enUpgradeButton:
                break;

            case EnSelectButton.enStoreButton:
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonScript : MonoBehaviour
{
    [SerializeField] GameObject SaveDatObject;
    [SerializeField] GameObject MaxLevel;
    [SerializeField] int value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        MenuData menuData = SaveDatObject.GetComponent<MenuData>();
        SaveData saveData = SaveDatObject.GetComponent<SaveData>();
        UpgradeTextScript upgradeTextScript = MaxLevel.GetComponent<UpgradeTextScript>();

        if (menuData.GetUpgrade(upgradeTextScript.Number - 1) >= upgradeTextScript.MaxLevel)
        {
            return;
        }
        if (saveData.GetItem() < value)
        { 
            return;
        }

        menuData.AddUpgrade(upgradeTextScript.Number - 1, 1);
        saveData.AddItem(-value);
    }
}

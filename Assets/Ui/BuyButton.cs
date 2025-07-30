using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
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
        StoreLevelTextScript upgradeTextScript = MaxLevel.GetComponent<StoreLevelTextScript>();

        if (menuData.GetUpgrade(upgradeTextScript.Number - 1) >= upgradeTextScript.MaxLevel)
        {
            return;
        }
        if (saveData.GetCoin() < value)
        {
            return;
        }
        menuData.AddStore(upgradeTextScript.Number - 1, 1);
        saveData.AddCoin(-value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownGrade : MonoBehaviour
{
    [SerializeField] GameObject Level;
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
        GameObject saveDataObject = GameObject.FindGameObjectWithTag("SaveData");
        MenuData menuData = saveDataObject.GetComponent<MenuData>();
        menuData.AddUpgrade(Level.GetComponent<UpgradeTextScript>().Number-1,-1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MenuManagerScript;

public class MenuButtonScript : MonoBehaviour
{
    [SerializeField] EnSelectButton enMenuButton;
    [SerializeField] GameObject menuObject;

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
        MenuManagerScript menuManagerScript = menuObject.GetComponent<MenuManagerScript>();
        menuManagerScript.OnMenuButton(enMenuButton);
    }
}

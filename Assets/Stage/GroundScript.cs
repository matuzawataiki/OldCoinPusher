using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField] bool GetCoin = true;
    [SerializeField] GameObject SaveDataObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (GetCoin) { 
            SaveData saveDataScript = SaveDataObject.GetComponent<SaveData>();
            saveDataScript.AddCoin(1);
        }
        Destroy(collision.gameObject);
    }
}

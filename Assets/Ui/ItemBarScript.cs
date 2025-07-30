using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBarScript : MonoBehaviour
{
    [SerializeField] GameObject SaveDataObject;
    SaveData saveDataScript;
    [SerializeField] const float MaxItemPint = 100.0f;
    [SerializeField] GameObject ItemObject;

    // Start is called before the first frame update
    void Start()
    {
        saveDataScript = SaveDataObject.GetComponent<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        float itemPoint = saveDataScript.GetPoint();
        if (itemPoint >= MaxItemPint)
        {
            AddItem();
            itemPoint -= MaxItemPint;
        }

        GetComponent<Slider>().value = itemPoint;
        saveDataScript.SetPoint(itemPoint);
    }

    private void AddItem()
    {
        GameObject gameObject = GameObject.Instantiate(ItemObject);
        float x = Random.Range(24, -24);
        gameObject.transform.SetPositionAndRotation(new Vector3(x, 25, 1),Quaternion.identity);
            
    }
}

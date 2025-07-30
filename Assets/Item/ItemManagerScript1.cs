using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerScript1 : MonoBehaviour
{
    [SerializeField] GameObject tawaraObject;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            float x = Random.Range(24, -24);
            GameObject coinTowerObj = Instantiate(tawaraObject, new Vector3(x, 25, 1), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 100 == 0)
        {
            float x = Random.Range(24, -24);
            GameObject coinTowerObj = Instantiate(tawaraObject, new Vector3(x, 25, 1), Quaternion.identity);
        }
    }
}

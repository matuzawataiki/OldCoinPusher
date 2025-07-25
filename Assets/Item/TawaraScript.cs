using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TawaraScript : ItemScript
{
    [SerializeField] GameObject tawaraPrefab; // •U‚ÌƒvƒŒƒnƒu
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 15.0f, Random.Range(-5.0f, 5.0f));
        GameObject coinObj = Instantiate(tawaraPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : ItemScript
{
    [SerializeField] GameObject coinPref; 
    bool isGameEnd = false; 
    // Start is called before the first frame update
    void Start()
    {
        // GameObject coinPrefab = Instantiate(coinObject, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameEnd == false)
        {
            //coinObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);
            if (Time.frameCount % 240 == 0)
            {

                Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 15.0f, Random.Range(-10.0f, 10.0f));
                GameObject coinObj = Instantiate(coinPref, pos, Quaternion.identity);
                //Rigidbody coinRid = coinObj.GetComponent<Rigidbody>();
                //coinRid.AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);
            }
        }
    }

}

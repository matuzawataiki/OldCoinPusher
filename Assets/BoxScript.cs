using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] GameObject PlayerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerObject.transform.position;
        transform.position += new Vector3(0.0f, -2.55f, 0.0f);
    }
}

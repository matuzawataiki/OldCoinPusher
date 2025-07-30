using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] GameObject PlayerObject;
    float boxPositionZ = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpgradeBoxSize(float upgrade)
    {
        Vector3 upgradeBoxSize = Vector3.one * upgrade;
        transform.localScale += upgradeBoxSize * 0.01f;
        boxPositionZ -= upgrade;
    }

    public void DowngradeBoxSize(float downgrade)
    {
        Vector3 downgradeBoxSize = Vector3.one * downgrade;
        transform.localScale -= downgradeBoxSize * 0.01f;
        boxPositionZ += downgrade;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerObject.transform.position;
        transform.position += new Vector3(0.0f, -2.55f, boxPositionZ);
    }
}

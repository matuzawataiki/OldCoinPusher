using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コインSEスクリプト
/// </summary>
public class CoinSEScript : MonoBehaviour
{
    //コインSE
    public AudioClip coinSE;

    //オーディオソース
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.clip = coinSE;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "coin(Clone)")
        {
            audioSource.PlayOneShot(coinSE);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

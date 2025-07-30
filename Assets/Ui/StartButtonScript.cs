using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] GameObject FadeObject;
    Image Image;
    bool isfade = false;
    float alpha = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Image = FadeObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isfade)
        {
            Image.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            alpha += Time.deltaTime / 2.0f;
        }
    }

    public void OnClick()
    {
        Invoke("ChangeScene", 2.5f);
        isfade = true;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("InGame");
    }
}

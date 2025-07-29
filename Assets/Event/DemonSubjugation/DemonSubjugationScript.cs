using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DemonMoveDirectionState
{
    Left,  // 左に移動
    Right, // 右に移動
}
public class DemonSubjugationScript : MonoBehaviour
{
    [SerializeField] GameObject DemonPurehaf; //ほねのプレハブを格納する変数
    private float EventTimeLimit = 20.0f;
    //private bool m_moveState = true; //trueなら右に移動、falseなら左に移動
    DemonMoveDirectionState moveDirectionState = DemonMoveDirectionState.Left;
    float moveSpeed = 10.0f;
    private float moveLimit = 25.0f;
    EventManagerScript eventManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f),11.0f,11.0f);
        //    GameObject DemonObj = Instantiate(DemonPurehaf, pos, Quaternion.identity);
        //    Vector3 UpperPos = new Vector3(Random.Range(-5.0f, 5.0f), 4.5f, 0.0f);
        //    GameObject UpperObj= Instantiate(DemonPurehaf, UpperPos, Quaternion.identity);
        //}

        eventManagerScript = GameObject.Find("EventManager").transform.GetComponent<EventManagerScript>();

        Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 11.0f, 11.0f);
        GameObject DemonObj = Instantiate(DemonPurehaf, pos, Quaternion.identity);
        DemonPurehaf = DemonObj;
        transform.position = DemonPurehaf.transform.position;
        transform.rotation = DemonPurehaf.transform.rotation;
        transform.localScale= DemonPurehaf.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //移動するメソッドを呼び出す
        if (EventTimeLimit <= 0.0f)
        {
            eventManagerScript.IsSkellEncounter = false; //イベント終了時にフラグをリセット
            Destroy(gameObject);
            Destroy(DemonPurehaf);
        }
        else
        {
            EventTimeLimit -= Time.deltaTime;
            //if (m_moveState == false)
            //{
            //    DemonPurehaf.transform.position += new Vector3(0.02f, 0.0f, 0.0f);
            //    DemonPurehaf.transform.Rotate(0.0f, 0.1f, 0.0f);
            //}
            //else
            //{
            //    DemonPurehaf.transform.position += new Vector3(-0.02f, 0.0f, 0.0f);
            //    DemonPurehaf.transform.Rotate(0.0f, 0.1f, 0.0f);
            //}

        }
    }
    private void Move()
    {
        //桶の移動方向に応じて移動処理を行う
        switch (moveDirectionState)
        {
            case DemonMoveDirectionState.Left:
                DemonPurehaf.transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                DemonPurehaf.transform.Rotate(0.0f, 1.0f, 0.0f);
                transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                transform.Rotate(0.0f, 1.0f, 0.0f);
                break;
            case DemonMoveDirectionState.Right:
                DemonPurehaf.transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                DemonPurehaf.transform.Rotate(0.0f, 1.0f, 0.0f);
                transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                transform.Rotate(0.0f, 1.0f, 0.0f);
                break;
        }

        //画面外に出たら反対側に移動する
        if (DemonPurehaf.transform.position.x < -moveLimit)
        {
            moveDirectionState = DemonMoveDirectionState.Right;
        }
        else if (DemonPurehaf.transform.position.x > moveLimit)
        {
            moveDirectionState = DemonMoveDirectionState.Left;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "coin(Clone)")
        {
            Destroy(DemonPurehaf);
            Destroy(gameObject);
        }
    }
}

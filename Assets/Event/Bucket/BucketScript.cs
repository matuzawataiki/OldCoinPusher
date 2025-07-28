using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum OkeMoveDirectionState
{
    Left,  // 左に移動
    Right, // 右に移動
}
public class BucketScript : MonoBehaviour
{
    private int EventCoin = 0;
    private float EventTimeLimit = 20.0f;
    private bool m_moveState = true; //trueなら右に移動、falseなら左に移動
    [SerializeField]GameObject CobanPrefab; // Prefab for the coban object
    [SerializeField] GameObject EventManager;
    EventManagerScript eventManagerScript; // EventManagerのスクリプトを格納する変数
    //桶の移動方向の状態を保持する変数
    OkeMoveDirectionState moveDirectionState = OkeMoveDirectionState.Left;

    //桶の移動速度
    float moveSpeed = 10.0f;
    private float moveLimit = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        EventCoin = 0;
        transform.position = new Vector3(0.0f, 9.0f, 11.0f);
        //eventManagerScript= EventManager.GetComponent<EventManagerScript>(); // EventManagerのスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //移動するメソッドを呼び出す
        if (EventTimeLimit <= 0.0f)
        {
            SpawnCoban(EventCoin);
            //eventManagerScript.IsOkeEncounter = false; //イベント終了時にフラグをリセット
            Destroy(gameObject);
        }
        else
        {
            EventTimeLimit -= Time.deltaTime;
            if (m_moveState==false)
            {
                transform.position += new Vector3(0.02f, 0.0f, 0.0f);
                transform.Rotate(0.0f, 0.1f, 0.0f);
            }
            else
            {
                transform.position += new Vector3(-0.02f, 0.0f, 0.0f);
                transform.Rotate(0.0f, 0.1f, 0.0f);
            }

        }
    }

    //イベント中に獲得したコインに応じてコバンを生成するメソッド
    private void SpawnCoban(int Coin)
    {
        int spawn = Coin / 10;
        switch (spawn){
            case 0:
                break;
            case 1:
                int rand = Random.Range(0, (int)WhichJackPotItem.numberOfJackPotItem);
                Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), 15.0f, Random.Range(-5.0f, 5.0f));
                GameObject coban = Instantiate(CobanPrefab, pos, Quaternion.identity);
                break;
            case 2:
                Vector3[] pos2 = RandomPos(2);
                for (int i = 0; i < 2; i++)
                {
                    GameObject coban2 = Instantiate(CobanPrefab, pos2[i], Quaternion.identity);
                }
                break;
            case 3:
                Vector3[] pos3 = RandomPos(3);
                for (int i = 0; i < 3; i++)
                {
                    GameObject coban3 = Instantiate(CobanPrefab, pos3[i], Quaternion.identity);
                }
                break;
            case 4:
                Vector3[] pos4 = RandomPos(4);
                for (int i = 0; i < 4; i++)
                {
                    GameObject coban4 = Instantiate(CobanPrefab, pos4[i], Quaternion.identity);
                }
                break;
            case 5:
                Vector3[] pos5 = RandomPos(5);
                    
                for (int i = 0; i < 5; i++)
                {
                    GameObject coban5 = Instantiate(CobanPrefab, pos5[i], Quaternion.identity);
                }
                break;
            default:
                break;


        }

    }
    //引数の数分のランダムな位置を生成するメソッド
    private Vector3[] RandomPos(int lottery)
    {
        Vector3[] pos= new Vector3[lottery];
        for (int i = 0; i < lottery; i++)
        {
            pos[i] = new Vector3(Random.Range(-5.0f, 5.0f), 15.0f, Random.Range(0.0f, 10.0f));
        }
        return pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BuketGround")
        {
            EventCoin += 1;
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        //桶の移動方向に応じて移動処理を行う
        switch (moveDirectionState)
        {
            case OkeMoveDirectionState.Left:
                transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                transform.Rotate(0.0f, 1.0f, 0.0f);
                break;
            case OkeMoveDirectionState.Right:
                transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                transform.Rotate(0.0f, 1.0f, 0.0f);
                break;
        }

        //画面外に出たら反対側に移動する
        if (transform.position.x < -moveLimit)
        {
            moveDirectionState = OkeMoveDirectionState.Right;
        }
        else if (transform.position.x > moveLimit)
        {
            moveDirectionState = OkeMoveDirectionState.Left;
        }
    }
}

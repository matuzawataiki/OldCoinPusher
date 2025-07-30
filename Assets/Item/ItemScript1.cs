using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript1 : MonoBehaviour
{
    [SerializeField] ItemType type;
    [SerializeField] int Point;
    public enum ItemType
    {
        enCoin,
        enItem,
        enTawara,
        enPrizes,
        enCoban
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (transform.gameObject.name == "coin(Clone)")
            {
                GameObject saveDataObject = GameObject.FindGameObjectWithTag("SaveData");
                SaveData saveDataScript = saveDataObject.GetComponent<SaveData>();
                if (!saveDataScript.IsJackpot())
                {
                    saveDataScript.AddJackpot(1);
                }
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerGround")
        {
            GameObject saveDataObject = GameObject.FindGameObjectWithTag("SaveData");
            GameObject enemyManager = GameObject.Find("EnemyManager");
            SaveData saveDataScript = saveDataObject.GetComponent<SaveData>();
            //EnemyManagerScript enemyManagerScript = enemyManager.GetComponent<EnemyManagerScript>();
            //enemyManagerScript.AddEnemySpawnCoinCount(1);
            switch (type)
            {
                case ItemType.enCoin:
                    saveDataScript.AddCoin(Point);
                    break;
                case ItemType.enItem:
                    saveDataScript.AddItem(Point);
                    break;
                case ItemType.enTawara:
                    saveDataScript.AddCoin(Point);
                    break;
                case ItemType.enPrizes:
                    saveDataScript.AddPoint(Point);
                    break;
                case ItemType.enCoban:
                    saveDataScript.AddCoban(Point);
                    break;
            }
            Destroy(gameObject);
        }
    }
}

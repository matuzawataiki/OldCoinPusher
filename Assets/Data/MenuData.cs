using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuData : MonoBehaviour
{
    [SerializeField] int[] m_itemNum = new int[5];
    [SerializeField] int[] m_monsterRecord = new int[2];
    [SerializeField] int[] m_upgrade = new int[8];
    [SerializeField] int[] m_store = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int GetItemNum(int itemNum){return m_itemNum[itemNum];}
    public void SetItemNum(int itemNum,int value){m_itemNum[itemNum] = value;}
    public void AddItemNum(int itemNum,int value){m_itemNum[itemNum] += value;}

    public int GetMonsterRecord(int monsterNum){return m_monsterRecord[monsterNum];}
    public void SetMonsterRecord(int monsterNum, int value){m_monsterRecord[monsterNum] = value;}
    public void AddMonsterRecord(int monsterNum, int value){m_monsterRecord[monsterNum] += value;}

    public int GetUpgrade(int upgradeNum){return m_upgrade[upgradeNum];}
    public void SetUpgrade(int upgradeNum, int value){ m_upgrade[upgradeNum] = value;}
    public void AddUpgrade(int upgradeNum, int value){ m_upgrade[upgradeNum] += value;}

    public int GetStore(int storeNum){return m_store[storeNum];}
    public void SetStore(int storeNum,int value){m_store[storeNum] = value;}
    public void AddStore(int storeNum, int value) { m_store[storeNum] += value; }

}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private int m_coin = 0;
    [SerializeField] private float m_point = 0;
    [SerializeField] private float m_jackpot = 0;
    [SerializeField] private int m_item = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoin(int coin){ m_coin = coin; }
    public int GetCoin() { return m_coin; }
    public void AddCoin(int coin) {  m_coin += coin; }

    public void SetPoint(float point) { m_point = point; }
    public float GetPoint() { return m_point; }
    public void AddPoint(float point) {m_point += point; }

    public void SetJackpot(float jackpot) {  m_jackpot = jackpot; }
    public float GetJackpot() {  return m_jackpot; }
    public void AddJackpot(float jackpot) { m_jackpot += jackpot; }

    public void SetItem(int item) { m_item = item; }
    public int GetItem() { return m_item; }
    public void AddItem(int item) {m_item += item; }








}

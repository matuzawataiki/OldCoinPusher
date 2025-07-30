using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using CI.QuickSave;
using CI.QuickSave.Core.Storage;


public class SaveData : MonoBehaviour
{
    [SerializeField] GameObject[] GameObjects = new GameObject[4];
    [SerializeField] private int m_coin = 0;
    [SerializeField] private float m_point = 0;
    [SerializeField] private float m_jackpot = 0;
    [SerializeField] private int m_item = 0;
    [SerializeField] private int m_coban = 0; //小判の数を格納する変数。
    [SerializeField] private int m_groundDownCoin = 0; //地面に落ちたコインの数を格納する変数
    private bool m_isJackpot = false; //ジャックポットが発生しているかどうかのフラグ
    QuickSaveSettings m_saveSettings;

    // Start is called before the first frame update
    void Start()
    {
        // QuickSaveSettings・ｽﾌイ・ｽ・ｽ・ｽX・ｽ^・ｽ・ｽ・ｽX・ｽ・ｽ・ｽ・ｬ
        m_saveSettings = new QuickSaveSettings();
        // ・ｽﾃ搾ｿｽ・ｽ・ｽ・ｽﾌ包ｿｽ・ｽ@ 
        m_saveSettings.SecurityMode = SecurityMode.Aes;
        // Aes・ｽﾌ暗搾ｿｽ・ｽ・ｽ・ｽL・ｽ[
        m_saveSettings.Password = "Password";
        // ・ｽ・ｽ・ｽk・ｽﾌ包ｿｽ・ｽ@
        m_saveSettings.CompressionMode = CompressionMode.Gzip;
        LoadUserData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            m_coin += 1000;
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            m_item += 10;
        }
    }

    /// <summary>
    /// ・ｽf・ｽ[・ｽ^・ｽZ・ｽ[・ｽu
    /// </summary>
    public void SaveUserData()
    {
        Debug.Log("・ｽZ・ｽ[・ｽu・ｽf・ｽ[・ｽ^・ｽﾛ托ｿｽ・ｽ・ｽ:" + Application.persistentDataPath);

        // QuickSaveWriter・ｽﾌイ・ｽ・ｽ・ｽX・ｽ^・ｽ・ｽ・ｽX・ｽ・ｽ・ｽ・ｬ
        QuickSaveWriter writer = QuickSaveWriter.Create("SaveData", m_saveSettings);

        // ・ｽf・ｽ[・ｽ^・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ
        writer.Write("CoinNum", m_coin);
        writer.Write("JackpotNum", m_jackpot);
        writer.Write("ItemNum", m_item);
        writer.Write("ItemPoint", m_point);

        // ・ｽﾏ更・ｽｽ映
        writer.Commit();
    }
    /// <summary>
    /// ・ｽZ・ｽ[・ｽu・ｽf・ｽ[・ｽ^・ｽﾇみ搾ｿｽ・ｽ・ｽ
    /// </summary>
    public void LoadUserData()
    {
        //・ｽt・ｽ@・ｽC・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽﾎ厄ｿｽ・ｽ・ｽ
        if (FileAccess.Exists("SaveData") == false)
        {
            return;
        }

        // QuickSaveReader・ｽﾌイ・ｽ・ｽ・ｽX・ｽ^・ｽ・ｽ・ｽX・ｽ・ｽ・ｽ・ｬ
        QuickSaveReader reader = QuickSaveReader.Create("SaveData", m_saveSettings);

        // ・ｽf・ｽ[・ｽ^・ｽ・ｽﾇみ搾ｿｽ・ｽ・ｽ
        m_coin = reader.Read<int>("CoinNum");
        m_jackpot = reader.Read<int>("JackpotNum");
        m_item = reader.Read<int>("ItemNum");
        m_point = reader.Read<int>("ItemPoint");
    }


    public void SetCoin(int coin){ m_coin = coin; }
    public int GetCoin() { return m_coin; }
    public void AddCoin(int coin)
    { 
        m_coin += coin;
        if (coin >= 20)
        {
            float x = Random.Range(24, -24);
            int num = Random.Range(0, 5);
            GameObject coinTowerObj = Instantiate(GameObjects[num], new Vector3(x, 25, 1), Quaternion.identity);
        }
    }

    public void SetPoint(float point) { m_point = point; }
    public float GetPoint() { return m_point; }
    public void AddPoint(float point) {m_point += point; }

    public void SetJackpot(float jackpot) {  m_jackpot = jackpot; }
    public float GetJackpot() {  return m_jackpot; }
    public void AddJackpot(float jackpot) { m_jackpot += jackpot; }
    public void SubtractJackpot(float jackpot) { m_jackpot -= jackpot; }
    public void SetJackpot(bool jackpot) { m_isJackpot = jackpot; }
    public bool IsJackpot() { return m_isJackpot; }

    public void SetItem(int item) { m_item = item; }
    public int GetItem() { return m_item; }
    public void AddItem(int item) {m_item += item; }

    public void SetCoban(int coban) { m_coban = coban; } //・ｽ・ｽ・ｽ・ｽ・ｽﾌ撰ｿｽ・ｽ・ｽﾝ定す・ｽ驛・ｿｽ\・ｽb・ｽh
    public int GetCoban() { return m_coban; } //・ｽ・ｽ・ｽ・ｽ・ｽﾌ撰ｿｽ・ｽ・ｽ・ｽ謫ｾ・ｽ・ｽ・ｽ驛・ｿｽ\・ｽb・ｽh
    public void AddCoban(int coban) { m_coban += coban; } //・ｽ・ｽ・ｽ・ｽ・ｽﾌ撰ｿｽ・ｽ・ｽﾇ会ｿｽ・ｽ・ｽ・ｽ驛・ｿｽ\・ｽb・ｽh

    public void SetGroundDownCoin(int coin) { m_groundDownCoin = coin; }

    public int GetGroundDownCoin() { return m_groundDownCoin; }

    public void AddGroundDownCoin(int coin) { m_groundDownCoin += coin; }






}

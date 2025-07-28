using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using CI.QuickSave;
using CI.QuickSave.Core.Storage;
using static UnityEditor.Progress;


public class SaveData : MonoBehaviour
{
    [SerializeField] private int m_coin = 0;
    [SerializeField] private float m_point = 0;
    [SerializeField] private float m_jackpot = 0;
    [SerializeField] private int m_item = 0;
    //セーブ設定
    QuickSaveSettings m_saveSettings;

    // Start is called before the first frame update
    void Start()
    {
        // QuickSaveSettingsのインスタンスを作成
        m_saveSettings = new QuickSaveSettings();
        // 暗号化の方法 
        m_saveSettings.SecurityMode = SecurityMode.Aes;
        // Aesの暗号化キー
        m_saveSettings.Password = "Password";
        // 圧縮の方法
        m_saveSettings.CompressionMode = CompressionMode.Gzip;
        LoadUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// データセーブ
    /// </summary>
    public void SaveUserData()
    {
        Debug.Log("セーブデータ保存先:" + Application.persistentDataPath);

        // QuickSaveWriterのインスタンスを作成
        QuickSaveWriter writer = QuickSaveWriter.Create("SaveData", m_saveSettings);

        // データを書き込む
        writer.Write("CoinNum", m_coin);
        writer.Write("JackpotNum", m_jackpot);
        writer.Write("ItemNum", m_item);
        writer.Write("ItemPoint", m_point);

        // 変更を反映
        writer.Commit();
    }
    /// <summary>
    /// セーブデータ読み込み
    /// </summary>
    public void LoadUserData()
    {
        //ファイルが無ければ無視
        if (FileAccess.Exists("SaveData") == false)
        {
            return;
        }

        // QuickSaveReaderのインスタンスを作成
        QuickSaveReader reader = QuickSaveReader.Create("SaveData", m_saveSettings);

        // データを読み込む
        m_coin = reader.Read<int>("CoinNum");
        m_jackpot = reader.Read<int>("JackpotNum");
        m_item = reader.Read<int>("ItemNum");
        m_point = reader.Read<int>("ItemPoint");
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

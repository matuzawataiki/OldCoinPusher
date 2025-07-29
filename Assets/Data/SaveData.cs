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
    //�Z�[�u�ݒ�
    QuickSaveSettings m_saveSettings;

    [SerializeField] private int m_coban = 0; //�����̐����i�[����ϐ��B
    // Start is called before the first frame update
    void Start()
    {
        // QuickSaveSettings�̃C���X�^���X���쐬
        m_saveSettings = new QuickSaveSettings();
        // �Í����̕��@ 
        m_saveSettings.SecurityMode = SecurityMode.Aes;
        // Aes�̈Í����L�[
        m_saveSettings.Password = "Password";
        // ���k�̕��@
        m_saveSettings.CompressionMode = CompressionMode.Gzip;
        LoadUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �f�[�^�Z�[�u
    /// </summary>
    public void SaveUserData()
    {
        Debug.Log("�Z�[�u�f�[�^�ۑ���:" + Application.persistentDataPath);

        // QuickSaveWriter�̃C���X�^���X���쐬
        QuickSaveWriter writer = QuickSaveWriter.Create("SaveData", m_saveSettings);

        // �f�[�^����������
        writer.Write("CoinNum", m_coin);
        writer.Write("JackpotNum", m_jackpot);
        writer.Write("ItemNum", m_item);
        writer.Write("ItemPoint", m_point);

        // �ύX�𔽉f
        writer.Commit();
    }
    /// <summary>
    /// �Z�[�u�f�[�^�ǂݍ���
    /// </summary>
    public void LoadUserData()
    {
        //�t�@�C����������Ζ���
        if (FileAccess.Exists("SaveData") == false)
        {
            return;
        }

        // QuickSaveReader�̃C���X�^���X���쐬
        QuickSaveReader reader = QuickSaveReader.Create("SaveData", m_saveSettings);

        // �f�[�^��ǂݍ���
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

    public void SetCoban(int coban) { m_coban = coban; } //�����̐���ݒ肷�郁�\�b�h
    public int GetCoban() { return m_coban; } //�����̐����擾���郁�\�b�h
    public void AddCoban(int coban) { m_coban += coban; } //�����̐���ǉ����郁�\�b�h






}

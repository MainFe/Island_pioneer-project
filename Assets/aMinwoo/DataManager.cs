using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerData //�÷��̾� ������ ���
{
    public string name;
    public int money = 0;
    public int item = 0;

}
public class DataManager : MonoBehaviour
{
    public static DataManager instance; //��Ŭ��
    public PlayerData nowPlayer = new PlayerData();
    public string path;
    public void Awake()//������ �ı� ����
    {
        #region �̱���
        if (instance == null) 
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
        path = Application.persistentDataPath+"/Save"; //���� ���� ����
    }
    public void SaveData()//Json�� �ܺη� ����
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path, data);
    }
    public void LoadData()//������ �ҷ�����
    {
        string data = File.ReadAllText(path);
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
    public void DataClear()
    {
        
    }
}

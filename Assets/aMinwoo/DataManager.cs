using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerData //플레이어 데이터 기록
{
    public string name;
    public int money = 0;
    public int item = 0;

}
public class DataManager : MonoBehaviour
{
    public static DataManager instance; //싱클톤
    public PlayerData nowPlayer = new PlayerData();
    public string path;
    public void Awake()//데이터 파괴 방지
    {
        #region 싱글톤
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
        path = Application.persistentDataPath+"/Save"; //저장 파일 생성
    }
    public void SaveData()//Json을 외부로 배출
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path, data);
    }
    public void LoadData()//데이터 불러오기
    {
        string data = File.ReadAllText(path);
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
    public void DataClear()
    {
        
    }
}

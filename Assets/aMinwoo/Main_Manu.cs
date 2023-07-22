using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.IO;
using System.Data;

public class Main_Manu : MonoBehaviour
{
   
    public void Start_button()//게임   시작하기위한 장면 전환
    {
        //저장된 기록이 없을시 사용됨
        DataManager.instance.SaveData();
        SceneManager.LoadScene("Game_screen");
        Debug.Log("게임 시작 확인");
      
 
         //저장된 게임 정보 불러오기
        DataManager.instance.LoadData();
        SceneManager.LoadScene("Game_screen");
        Debug.Log("게임 시작 확인");
        
        
        
    }
    public void ending_button()//엔딩 크래딧 장면 전환
    {
        SceneManager.LoadScene("");
        Debug.Log("엔딩 크래딧 확인");
    }
    public void end_button()//게임 종료 기능
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}

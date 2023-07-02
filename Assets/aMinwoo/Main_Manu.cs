using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Manu : MonoBehaviour
{

    public void Start_button()//게임 시작하기위한 장면 전환
    {
        SceneManager.LoadScene("");
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

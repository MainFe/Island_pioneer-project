using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Manu : MonoBehaviour
{

    public void Start_button()//���� �����ϱ����� ��� ��ȯ
    {
        SceneManager.LoadScene("");
        Debug.Log("���� ���� Ȯ��");
    }
    public void ending_button()//���� ũ���� ��� ��ȯ
    {
        SceneManager.LoadScene("");
        Debug.Log("���� ũ���� Ȯ��");
    }
    public void end_button()//���� ���� ���
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}

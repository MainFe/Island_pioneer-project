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
   
    public void Start_button()//����   �����ϱ����� ��� ��ȯ
    {
        //����� ����� ������ ����
        DataManager.instance.SaveData();
        SceneManager.LoadScene("Game_screen");
        Debug.Log("���� ���� Ȯ��");
      
 
         //����� ���� ���� �ҷ�����
        DataManager.instance.LoadData();
        SceneManager.LoadScene("Game_screen");
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

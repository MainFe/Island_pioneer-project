using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoer : MonoBehaviour
{
    public int itemCount;
    public Text Rubytext;
    public Text Diamondtext;     //����ǥ��
    public Text money;
    int Diamond = 0, Ruby = 0;
    private void Start()  //����ǥ��
    {
        
        money.text += DataManager.instance.nowPlayer.money.ToString();
    }
    

    public void GetDiamond()  //���� �ݾ�
    {
        Diamond += 1;
        Diamondtext.text = "���̾�: "+((int)Diamond).ToString();
    }

    public void GetRuby()    //���� ���ݾ�
    {
        Ruby += 1;
        Rubytext.text = "���: "+((int)Ruby).ToString();
    }
    public void GetMoney()  //�������� ��
    {
        DataManager.instance.nowPlayer.money += 100;
        money.text = "��: "+DataManager.instance.nowPlayer.money.ToString();
    }
    public void Exit() //������ ������ ���� �ջ��� ����
    {
        DataManager.instance.nowPlayer.money += Diamond * 100;
        DataManager.instance.nowPlayer.money += Ruby * 50;
        DataManager.instance.SaveData();
        SceneManager.LoadScene("Main_Menu");
    }
}

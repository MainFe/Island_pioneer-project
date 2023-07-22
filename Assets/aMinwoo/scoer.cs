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
    public Text Diamondtext;     //점수표시
    public Text money;
    int Diamond = 0, Ruby = 0;
    private void Start()  //점수표시
    {
        
        money.text += DataManager.instance.nowPlayer.money.ToString();
    }
    

    public void GetDiamond()  //높은 금액
    {
        Diamond += 1;
        Diamondtext.text = "다이아: "+((int)Diamond).ToString();
    }

    public void GetRuby()    //낮은 점금액
    {
        Ruby += 1;
        Rubytext.text = "루비: "+((int)Ruby).ToString();
    }
    public void GetMoney()  //직접얻은 돈
    {
        DataManager.instance.nowPlayer.money += 100;
        money.text = "돈: "+DataManager.instance.nowPlayer.money.ToString();
    }
    public void Exit() //게임을 끝낼때 최종 합산후 저장
    {
        DataManager.instance.nowPlayer.money += Diamond * 100;
        DataManager.instance.nowPlayer.money += Ruby * 50;
        DataManager.instance.SaveData();
        SceneManager.LoadScene("Main_Menu");
    }
}

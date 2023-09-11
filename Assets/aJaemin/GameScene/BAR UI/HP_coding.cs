using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_mp_update : MonoBehaviour
{
    public Slider hp_slider;
    // public Slider exp_slider; 아직 사용x
    public Text hp_text;
    // public Text exp_text; 아직 사용x
    public Camera cam;
    public Stats stats;

    void Start()
    {
        cam = Camera.main;
        stats = cam.GetComponent<Camera_Work>().player.GetComponent<Stats>(); //스텟 스크립트 지정 UI는 따로 떨어져있기때문에 다른 오브젝트에서 값을 빌려와야 함
        hp_slider = GameObject.Find("hp_slider").GetComponent<Slider>();
        hp_slider.minValue = 0;

    }
    void Update()
    {
        hp_slider.maxValue = stats.maxHp;//슬라이더의 최대값을 스텟의 최대체력으로 지정
        hp_slider.value = stats.hp;//슬라이더의 값을 스텟의 체력으로 지정
        hp_text.text = (stats.hp.ToString() + "/" + stats.maxHp.ToString());//텍스트의 값을 스텟의 체력으로 지정

    }

}
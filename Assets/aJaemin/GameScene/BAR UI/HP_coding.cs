using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_mp_update : MonoBehaviour
{
    public Slider hp_slider;
    // public Slider exp_slider; ���� ���x
    public Text hp_text;
    // public Text exp_text; ���� ���x
    public Camera cam;
    public Stats stats;

    void Start()
    {
        cam = Camera.main;
        stats = cam.GetComponent<Camera_Work>().player.GetComponent<Stats>(); //���� ��ũ��Ʈ ���� UI�� ���� �������ֱ⶧���� �ٸ� ������Ʈ���� ���� �����;� ��
        hp_slider = GameObject.Find("hp_slider").GetComponent<Slider>();
        hp_slider.minValue = 0;

    }
    void Update()
    {
        hp_slider.maxValue = stats.maxHp;//�����̴��� �ִ밪�� ������ �ִ�ü������ ����
        hp_slider.value = stats.hp;//�����̴��� ���� ������ ü������ ����
        hp_text.text = (stats.hp.ToString() + "/" + stats.maxHp.ToString());//�ؽ�Ʈ�� ���� ������ ü������ ����

    }

}
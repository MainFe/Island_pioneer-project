using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    //ü��
    [SerializeField]
    private int hp;
    private int currentHp;
    
    /* //ü���� �پ��� �ӵ�
    [SerializeField]
    private int hpDecreaseTime;
    private int currentHpDecreaseTime;
    */

    //�����
    [SerializeField]
    private int hungry;
    private int currentHungry;

    //������� �پ��� �ӵ�
    [SerializeField]
    private int hungryDecreaseTime;
    private int currentHungryDecreaseTime;

    //����
    [SerializeField]
    private int cold;
    private int currentCold;

    //ü��, �����, ���� ����
    [SerializeField]
    private Slider[] sliders_Gauge;
    private const int HP = 0, HUNGRY = 1, COLD = 2;

    void Start()
    {
        currentHp = hp;
        currentHungry = hungry;
        currentCold = cold;
    }

    // Update is called once per frame
    void Update()
    {
        Hungry();
        GaugeUpdate();
    }

    private void Hungry()
    {
        if (currentHungry > 0)
        {
            if (currentHungryDecreaseTime <= hungryDecreaseTime)
                currentHungryDecreaseTime++;
            else
            {
                currentHungry--;
                currentHungryDecreaseTime = 0;
            }
        }
        else
        {
            Debug.Log("����� ��ġ�� 0�� �Ǿ����ϴ�.");
            DecreaseHP(1);
        }
    }

    private void GaugeUpdate()
    {
        sliders_Gauge[HP].value = (float)currentHp / hp;
        sliders_Gauge[HUNGRY].value = (float)currentHungry / hungry;
        sliders_Gauge[COLD].value = (float)currentCold / cold;
    }

    public void IncreaseHP(int _count)
    {
        if (currentHp + _count < hp)
            currentHp += _count;
        else
            currentHp = hp;
    }

    public void DecreaseHP(int _count)
    {
        currentHp -= _count;

        if (currentHp <= 0)
            Debug.Log("ü�� ��ġ�� 0�� �Ǿ����ϴ�.");
    }

    public void IncreaseHungry(int _count)
    {
        if (currentHungry + _count < hungry)
            currentHungry += _count;
        else
            currentHungry = hungry;
    }

    public void DecreaseHungry(int _count)
    {
        if (currentHungry - _count < 0)
            currentHungry = 0;
        else
            currentHungry -= _count;
    }
}

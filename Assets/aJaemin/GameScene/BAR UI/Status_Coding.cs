using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    //체력
    [SerializeField]
    private int hp;
    private int currentHp;
    
    /* //체력이 줄어드는 속도
    [SerializeField]
    private int hpDecreaseTime;
    private int currentHpDecreaseTime;
    */

    //배고픔
    [SerializeField]
    private int hungry;
    private int currentHungry;

    //배고픔이 줄어드는 속도
    [SerializeField]
    private int hungryDecreaseTime;
    private int currentHungryDecreaseTime;

    //추위
    [SerializeField]
    private int cold;
    private int currentCold;

    //체력, 배고픔, 추위 순서
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
            Debug.Log("배고픔 수치가 0이 되었습니다.");
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
            Debug.Log("체력 수치가 0이 되었습니다.");
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

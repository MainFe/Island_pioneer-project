using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Slots[] slots = new Slots[10];
    [SerializeField] GameObject InventoryUI;

    /*
    public void PickUpItem(ItemObject obj) //아이템을 줍는다.
    {
        for (int i = 0; i < slots.Length; i++)
        {
            {
                if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id) //슬롯에 아이템이 있고 id가 같을 경우
                {
                    Debug.Log("아이템 중복");
                }
                else
                {
                    Debug.Log("아이템 획득");
                    slots[i].ItemInSlot = obj.itemStats;
                    Destroy(obj.gameObject);
                    slots[i].SetStats();
                    return;
                }
            }
        }
    }
    */
    public void PickUpItem(ItemObject obj)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // 만약 슬롯에 아이템이 있고, 슬롯의 아이템 ID가 주어진 아이템의 ID와 일치하며, 슬롯이 가득 차지 않았을 경우
            if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id && slots[i].AmountInSlot != slots[i].ItemInSlot.maxStack)
            {
                // 만약 해당 아이템을 추가했을 때 슬롯이 가득 찰 것 같지 않으면
                if (!WillHitMaxStack(i, obj.amount))
                {
                    // 슬롯에 아이템을 추가하고, 주어진 아이템 오브젝트를 파괴한 후 슬롯의 통계를 설정하고 반환
                    slots[i].AmountInSlot += obj.amount;
                    Destroy(obj.gameObject);
                    slots[i].SetStats();
                    return;
                }
                else // 만약 해당 아이템을 추가했을 때 슬롯이 가득 찰 것 같으면
                {
                    // 슬롯에 추가로 필요한 아이템의 양을 계산하여 result 변수에 저장
                    int result = NeededToFill(i);
                    // 주어진 아이템의 양에서 남은 양을 계산하여 obj.amount에 할당
                    obj.amount = RemainingAmount(i, obj.amount);
                    // 슬롯에 result만큼 아이템을 추가하고, 슬롯의 통계를 설정한 후 재귀적으로 PickUpItem 메서드를 호출
                    slots[i].AmountInSlot += result;
                    slots[i].SetStats();
                    PickUpItem(obj);
                    return;
                }
            }
            // 만약 슬롯에 아무 아이템도 없을 경우
            else if (slots[i].ItemInSlot == null)
            {
                // 슬롯에 주어진 아이템을 추가하고, 주어진 아이템 오브젝트를 파괴한 후 슬롯의 통계를 설정하고 반환
                slots[i].ItemInSlot = obj.itemStats;
                slots[i].AmountInSlot += obj.amount;
                Destroy(obj.gameObject);
                slots[i].SetStats();
                return;
            }
        }
    }

    bool WillHitMaxStack(int index, int amount)
    {
        // 슬롯에 추가될 아이템의 양을 고려했을 때, 슬롯이 가득 찰 것 같은지 확인
        if (slots[index].ItemInSlot.maxStack <= slots[index].AmountInSlot + amount)
            return true; // 슬롯이 가득 찰 것 같으면 true 반환
        else
            return false; // 슬롯이 가득 차지 않을 것 같으면 false 반환
    }

    int NeededToFill(int index)
    {
        // 슬롯에 추가로 필요한 아이템의 양을 계산하여 반환
        return slots[index].ItemInSlot.maxStack - slots[index].AmountInSlot;
    }

    int RemainingAmount(int index, int amount)
    {
        // 슬롯에 추가될 아이템의 양에서 슬롯에 남는 양을 계산하여 반환
        return (slots[index].AmountInSlot + amount) - slots[index].ItemInSlot.maxStack;
    }
}

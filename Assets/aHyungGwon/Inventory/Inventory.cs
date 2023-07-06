using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Slots[] slots = new Slots[40];
    [SerializeField] GameObject InventoryUI;

    public void PickUpItem(ItemObject obj) //아이템을 줍는다.
    {
        for(int i = 0; i < slots.Length; i++) {
            {
                if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id) //슬롯에 아이템이 있고 id가 같을 경우
                {
                    Debug.Log("아이템 중복");
                    return;
                }
                else if(slots[i].ItemInSlot == null) //슬롯이 비었을때
                {
                    slots[i].ItemInSlot = obj.itemStats;
                    Destroy(obj.gameObject);
                    slots[i].SetStats();
                    return;
                }
            }   
        }
    }
}

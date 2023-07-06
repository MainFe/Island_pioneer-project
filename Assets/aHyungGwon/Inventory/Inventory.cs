using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Slots[] slots = new Slots[40];
    [SerializeField] GameObject InventoryUI;

    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ItemInSlot == null)
            {
                for (int k = 0; k < slots[i].transform.childCount; k++)
                {
                    Debug.Log("초기화");
                    slots[i].transform.GetChild(k).gameObject.SetActive(false);
                }
            }
        }
    }

    public void PickUpItem(ItemObject obj)
    {
        for(int i = 0; i < slots.Length; i++) {
            {
                if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id) //슬롯에 아이템이 있고 먹는 아이템과 아이디가 같을때
                {
                    Debug.Log("중복 아이템");
                }
                if (slots[i].ItemInSlot == null) //슬롯에 아이템이 없을 때
                {
                    slots[i].ItemInSlot = obj.itemStats;
                    Destroy(obj.gameObject);
                    slots[i].SetStats();
                    return;
                }
            } }
    }
}

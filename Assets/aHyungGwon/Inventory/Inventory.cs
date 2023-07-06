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
                    slots[i].transform.GetChild(k).gameObject.SetActive(false);
                }
            }
        }
    }

    private void Update()
    {
        
    }

    public void PickUpItem(ItemObject obj)
    {
        for(int i = 0; i < slots.Length; i++) {
            {
                if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id) //���Կ� �������� �ְ� id�� ���� ���
                {
                    Debug.Log("������ �ߺ�");
                    return;
                }
                else if(slots[i].ItemInSlot == null)
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

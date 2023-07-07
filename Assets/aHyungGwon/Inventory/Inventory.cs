using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Slots[] slots = new Slots[40];
    [SerializeField] GameObject InventoryUI;

    public void PickUpItem(ItemObject obj) //�������� �ݴ´�.
    {
        for(int i = 0; i < slots.Length; i++) {
            {
                if (slots[i]!=null && slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id) //���Կ� �������� �ְ� id�� ���� ���
                {
                    Debug.Log("������ �ߺ�");
                }else {
                    Debug.Log("������ ȹ��");
                    slots[i] = gameObject.AddComponent<Slots>();
                    slots[i].ItemInSlot = obj.itemStats;
                    Destroy(obj.gameObject);
                    slots[i].SetStats();
                    return;
                }
            }   
        }
    }
}

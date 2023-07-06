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
                    Debug.Log("�ʱ�ȭ");
                    slots[i].transform.GetChild(k).gameObject.SetActive(false);
                }
            }
        }
    }

    public void PickUpItem(ItemObject obj)
    {
        for(int i = 0; i < slots.Length; i++) {
            {
                if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id) //���Կ� �������� �ְ� �Դ� �����۰� ���̵� ������
                {
                    Debug.Log("�ߺ� ������");
                }
                if (slots[i].ItemInSlot == null) //���Կ� �������� ���� ��
                {
                    slots[i].ItemInSlot = obj.itemStats;
                    Destroy(obj.gameObject);
                    slots[i].SetStats();
                    return;
                }
            } }
    }
}

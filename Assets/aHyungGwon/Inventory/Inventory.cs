using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Slots[] slots = new Slots[10];
    [SerializeField] GameObject InventoryUI;

    /*
    public void PickUpItem(ItemObject obj) //�������� �ݴ´�.
    {
        for (int i = 0; i < slots.Length; i++)
        {
            {
                if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id) //���Կ� �������� �ְ� id�� ���� ���
                {
                    Debug.Log("������ �ߺ�");
                }
                else
                {
                    Debug.Log("������ ȹ��");
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
            // ���� ���Կ� �������� �ְ�, ������ ������ ID�� �־��� �������� ID�� ��ġ�ϸ�, ������ ���� ���� �ʾ��� ���
            if (slots[i].ItemInSlot != null && slots[i].ItemInSlot.id == obj.itemStats.id && slots[i].AmountInSlot != slots[i].ItemInSlot.maxStack)
            {
                // ���� �ش� �������� �߰����� �� ������ ���� �� �� ���� ������
                if (!WillHitMaxStack(i, obj.amount))
                {
                    // ���Կ� �������� �߰��ϰ�, �־��� ������ ������Ʈ�� �ı��� �� ������ ��踦 �����ϰ� ��ȯ
                    slots[i].AmountInSlot += obj.amount;
                    Destroy(obj.gameObject);
                    slots[i].SetStats();
                    return;
                }
                else // ���� �ش� �������� �߰����� �� ������ ���� �� �� ������
                {
                    // ���Կ� �߰��� �ʿ��� �������� ���� ����Ͽ� result ������ ����
                    int result = NeededToFill(i);
                    // �־��� �������� �翡�� ���� ���� ����Ͽ� obj.amount�� �Ҵ�
                    obj.amount = RemainingAmount(i, obj.amount);
                    // ���Կ� result��ŭ �������� �߰��ϰ�, ������ ��踦 ������ �� ��������� PickUpItem �޼��带 ȣ��
                    slots[i].AmountInSlot += result;
                    slots[i].SetStats();
                    PickUpItem(obj);
                    return;
                }
            }
            // ���� ���Կ� �ƹ� �����۵� ���� ���
            else if (slots[i].ItemInSlot == null)
            {
                // ���Կ� �־��� �������� �߰��ϰ�, �־��� ������ ������Ʈ�� �ı��� �� ������ ��踦 �����ϰ� ��ȯ
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
        // ���Կ� �߰��� �������� ���� ������� ��, ������ ���� �� �� ������ Ȯ��
        if (slots[index].ItemInSlot.maxStack <= slots[index].AmountInSlot + amount)
            return true; // ������ ���� �� �� ������ true ��ȯ
        else
            return false; // ������ ���� ���� ���� �� ������ false ��ȯ
    }

    int NeededToFill(int index)
    {
        // ���Կ� �߰��� �ʿ��� �������� ���� ����Ͽ� ��ȯ
        return slots[index].ItemInSlot.maxStack - slots[index].AmountInSlot;
    }

    int RemainingAmount(int index, int amount)
    {
        // ���Կ� �߰��� �������� �翡�� ���Կ� ���� ���� ����Ͽ� ��ȯ
        return (slots[index].AmountInSlot + amount) - slots[index].ItemInSlot.maxStack;
    }
}

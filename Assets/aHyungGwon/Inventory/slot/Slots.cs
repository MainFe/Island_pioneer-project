using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item ItemInSlot;

    private Image image;

    public void SetStats() //�ڽĿ��� �̹��� �ݿ�
    {
        image = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        Debug.Log("�̹��� �Ҵ�");
        Debug.Log(image);
        image.sprite = ItemInSlot.itemImage;
    }
}

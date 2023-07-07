using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item ItemInSlot;

    RawImage image;

    public void SetStats()
    {
        SetStats(image);
    }

    public void SetStats(RawImage image) //�ڽĿ��� �̹��� �ݿ�
    {
        image = GetComponentInChildren<RawImage>();
        Debug.Log("�̹��� �Ҵ�");
        Debug.Log(image);
        image.texture = ItemInSlot.itemImage;
    }
}

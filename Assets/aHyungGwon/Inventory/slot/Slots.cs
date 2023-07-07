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

    public void SetStats(RawImage image) //자식에게 이미지 반영
    {
        image = GetComponentInChildren<RawImage>();
        Debug.Log("이미지 할당");
        Debug.Log(image);
        image.texture = ItemInSlot.itemImage;
    }
}

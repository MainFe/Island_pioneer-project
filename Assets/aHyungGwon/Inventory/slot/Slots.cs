using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item ItemInSlot;
    public int AmountInSlot;

    RawImage image;

    public void SetStats() //자식에게 이미지 반영
    {
        image = transform.GetChild(0).GetChild(0).GetComponent<RawImage>();
        image.texture = ItemInSlot.itemImage;
    }
}

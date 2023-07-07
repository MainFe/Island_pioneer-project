using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item ItemInSlot;

    private Image image;

    public void SetStats() //자식에게 이미지 반영
    {
        image = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        Debug.Log("이미지 할당");
        Debug.Log(image);
        image.sprite = ItemInSlot.itemImage;
    }
}

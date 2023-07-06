using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item ItemInSlot;

    Sprite image;

    public void SetStats() //자식에게 이미지 반영
    {
        image = this.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite;        
        image = ItemInSlot.itemImage;
    }
}

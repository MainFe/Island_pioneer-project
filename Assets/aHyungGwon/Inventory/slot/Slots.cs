using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots : MonoBehaviour
{
    public Item ItemInSlot;

    RawImage image;

    public void SetStats()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        image = GetComponentInChildren<RawImage>();
        image.texture = ItemInSlot.itemImage;
    }
}

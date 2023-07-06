using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots : MonoBehaviour
{
    public Item ItemInSlot;
    public int AmountInSlot;

    RawImage image;
    TextMeshProUGUI txt_amount;

    public void SetStats()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        image = GetComponentInChildren<RawImage>();
        txt_amount = GetComponentInChildren<TextMeshProUGUI>();

        image.texture = ItemInSlot.itemImage;
        txt_amount.text = $"{AmountInSlot}x";
    }
}

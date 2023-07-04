using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
}

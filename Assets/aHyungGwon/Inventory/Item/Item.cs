using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite itemImage;
}

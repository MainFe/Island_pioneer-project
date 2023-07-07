using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;

    [TextArea(3, 3)] public string discription;

    public enum Types
    {
        food,
        equipment,
        craftingMaterial
    }
    public Types type;
    public GameObject prefab; 
    public Texture itemImage;
}

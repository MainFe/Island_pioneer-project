using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        ListItem();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItem();
    }

    public void ListItem()
    {
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemImage = obj.transform.Find("ItemImage").GetComponent<Image>();

            itemImage.sprite = item.itemImage;
        }
    }
}

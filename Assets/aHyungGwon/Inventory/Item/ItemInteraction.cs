using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    RaycastHit hit;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.PickUpItem(hit.collider.GetComponent<ItemObject>());
        }
    }
}

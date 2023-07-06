using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    RaycastHit hit;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Inventory.PickUpItem(hit.collider.GetComponent<ItemObject>());
        }
    }
}

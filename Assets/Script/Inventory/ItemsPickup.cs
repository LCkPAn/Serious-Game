using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickup : MonoBehaviour
{
    public Item item;

    public void Pickup()
    {
        Inventory.Instance.Add(item);
        Destroy(gameObject);
    }
}

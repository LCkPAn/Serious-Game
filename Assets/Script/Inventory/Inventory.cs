using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        int nbItems = Items.Count - 1;

        transform.GetChild(nbItems).GetChild(0).GetComponent<Image>().sprite = item.icon;
        transform.GetChild(nbItems).GetChild(1).GetComponent<Text>().text = item.itemName;
    }


}

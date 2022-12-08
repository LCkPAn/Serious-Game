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

    /*public void ListItems()
    {
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem);
            var itemName = obj.GetComponentInChildren<Text>();
            var itemIcon = obj.GetComponentInChildren<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            obj.transform.SetParent(ItemContent);
            obj.transform.localPosition = Vector3.zero;

            ItemContent.Add(obj);
        }
    }

    /* public void closeInventory()
    {
        foreach (Transform item in ItemContent)
        {
            GameObject.Destroy(item.gameObject);
        }
    }*/


    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

}

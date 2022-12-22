using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public static List<Item> Items = new List<Item>();


    public DoorAnim doorAnim;

    private void Awake()
    {
        Instance = this;
    }


    // récupére les objets et les mets dans mon inventaires
    public void Add(Item item)
    {
        Items.Add(item);

        int nbItems = Items.Count - 1;

        transform.GetChild(nbItems).GetChild(0).GetComponent<Image>().sprite = item.icon;
        transform.GetChild(nbItems).GetChild(1).GetComponent<Text>().text = item.itemName;

         if (Items.Count == 3)
         {
             doorAnim.OpenIsDoor();
         }
    }
}

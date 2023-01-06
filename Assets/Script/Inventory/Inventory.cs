using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public static List<Item> Items = new List<Item>();



    public GameObject shakeDoor;
    public bool activeDoor = false;

    //public TextMeshProUGUI messageText;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
      activeDoor = false;
    }

    // récupére les objets et les mets dans mon inventaires
    public void Add(Item item)
    {
        Items.Add(item);
        int nbItems = Items.Count - 1;
        transform.GetChild(nbItems).GetChild(0).GetComponent<Image>().sprite = item.icon;
        if (Items.Count == 3)
         {
            shakeDoor.GetComponent<MeshRenderer>().material.DOFade(0.3f, 1).SetLoops(-1,LoopType.Yoyo);
            activeDoor = true;
         }
    }
}

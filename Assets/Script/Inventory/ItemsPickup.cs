using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemsPickup : MonoBehaviour
{
    public Item item;
    public GameObject moveInventory;
    //public Image itemIventory;
    public Image image;

    public void Pickup()
    {
        Inventory.Instance.Add(item);
        ItemTween();
        StartCoroutine(WaitDestroy());
    }

    public void ItemTween()
    {
        moveInventory.transform.DOMove(image.transform.position, 1);
        moveInventory.transform.DOScale(0.2f, 1f);
    }

    IEnumerator WaitDestroy()
     {
        yield return new WaitForSeconds(2);
        image.transform.DOScale(1.2f, 0.5f).OnComplete(() => image.transform.DOScale(1f, 0.5f));
        Destroy(gameObject);
        //image.transform.DOScale(1f, 1f).OnComplete(() => Destroy(gameObject));
        //image.rectTransform.DOLocalMoveY(50f, 1f / 2).

     }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemsPickup : MonoBehaviour
{
    public Item item;
    public Image image;
    public DialogueManager dialogManager;

    public void Pickup()
    {
        Inventory.Instance.Add(item);
        ItemTween();
        dialogManager.SetView();
        //StartCoroutine(WaitDestroy());
    }

    public void ItemTween()
    {
        transform.DOMove(image.transform.position, 1);
        transform.DOScale(0.2f, 1f).OnComplete(() => {
            image.transform.DOScale(1.2f, 0.2f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear);
            Destroy(gameObject);

        }); 
    }

    IEnumerator WaitDestroy()
     {
        yield return new WaitForSeconds(1);
        image.transform.DOScale(1.2f, 0.5f).OnComplete(() => image.transform.DOScale(1f, 0.5f));
        Destroy(gameObject);
        //image.transform.DOScale(1f, 1f).OnComplete(() => Destroy(gameObject));
        //image.rectTransform.DOLocalMoveY(50f, 1f / 2).
     }


}

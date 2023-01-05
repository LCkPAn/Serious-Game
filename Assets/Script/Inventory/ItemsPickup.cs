using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ItemsPickup : MonoBehaviour
{
    public Item item;
    public Image image;
    public Image panelDialog;

    public TextMeshProUGUI messageText;

    public GameObject pickupEffect;

    public void Start()
    {
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 0f);
    }

    void Show(string title, string message)
    {
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 255f);
        messageText.text = message;
    }

    public void Pickup()
    {
        Inventory.Instance.Add(item);
        transform.DOMove(image.transform.position, 1);
        transform.DOScale(0f, 1f).OnComplete(() => {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            StartCoroutine(OffDialog());
            image.transform.DOScale(1.3f, 0.3f).SetEase(Ease.Linear);
            panelDialog.GetComponent<Image>().DOFillAmount(1, 0.3f);
            switch (item.itemName)
            {
                case "Diplome":
                    Show("Titre", "Vous avez trouvé une clef !");
                    break;

                case "Medaille":
                    Show("Titre", "Vous avez trouvé une clef !");
                    break;

                case "Chapeau":
                    Show("Titre", "Vous avez trouvé une clef !");
                    break;
            }
        });
    }

    IEnumerator OffDialog()
    {
        //image.transform.DOScale(1f, 0.3f).SetEase(Ease.Linear);
        //panelDialog.GetComponent<Image>().DOFade(0, 0.3f);
        yield return new WaitForSeconds(5);
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 0f);
        image.transform.DOScale(1f, 0.3f).SetEase(Ease.Linear);
        panelDialog.GetComponent<Image>().DOFade(0, 0.3f);
    }

}

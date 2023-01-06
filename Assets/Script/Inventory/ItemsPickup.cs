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


    public void Start()
    {
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 0f);
        TutoStart();
    }

    public void TutoStart()
    {
        Show("Titre", "Help me to find a memory trough objects");
        image.transform.DOScale(1.3f, 0.3f).SetEase(Ease.Linear);
        panelDialog.GetComponent<Image>().DOFillAmount(1, 0.3f).OnComplete(() =>
        {
            StartCoroutine(OffDialog());
        });
            
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
        transform.DOScale(0f, 1f).OnComplete(() => 
        {
            StartCoroutine(OffDialog());
            image.transform.DOScale(1.3f, 0.3f).SetEase(Ease.Linear);
            panelDialog.GetComponent<Image>().DOFillAmount(1, 0.3f);
            switch (item.itemName)
            {
                case "Diplome":
                    Show("Titre", "At that time it was one and the same trade");
                    break;

                case "Medaille":
                    Show("Titre", "My most prestigious award for a surgical procedure !");
                    break;

                case "Chapeau":
                    Show("Titre", "A war memory... When I met the king");
                    break;

                case "Scalpel":
                    Show("Titre", "The tool that paved the way for surgery");
                    break;

                case "Lettre":
                    Show("Titre", "The King's seal ? I have to go to Paris !");
                    break;

                case "Heart":
                    Show("Titre", "The first, the first! I was the first surgeon in France !");
                    break;

            }
        });
    }

    IEnumerator OffDialog()
    {
        yield return new WaitForSeconds(5);
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 0f);
        image.transform.DOScale(1f, 0.3f).SetEase(Ease.Linear);
        panelDialog.GetComponent<Image>().DOFillAmount(0, 0.3f);
    }

}

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
                    Show("Titre", "At that time, barber and surgeon were one and the same profession");
                    break;

                case "Medaille":
                    Show("Titre", "My most prestigious award for a surgical procedure !");
                    break;

                case "Chapeau":
                    Show("Titre", "A war memory... When I met the king");
                    break;

                case "Casque":
                    Show("Titre", "Bad memory. It was during the war that I discovered the epidemic that struck certain cities");
                    break;

                case "Scalpel":
                    Show("Titre", "The tool that paved the way for surgery");
                    break;

                case "Lettre":
                    Show("Titre", "The King's seal ? I have to go to Paris !");
                    break;

                case "Book":
                    Show("Titre", "The theory that earned me a place in the philosophical 'Lumières' !");
                    break;

                case "Coffre":
                    Show("Titre", " A chest ? It's the last gift from my students!");
                    break;

                case "Ceinture":
                    Show("Titre", " The time when I was a state councillor and doctor to the king");
                    break;

                case "Poncon":
                    Show("Titre", "The first, the first! I was the first surgeon in France !");
                    break;

                case "Medaille2":
                    Show("Titre", "Napoleon offered it to me for my medical services");
                    break;

                case "stetoscope":
                    Show("Titre", "Even if I didn't know him, he remains an essential tool in my branch");
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

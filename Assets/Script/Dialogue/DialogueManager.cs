using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text titleText;
    public Text messageText;
    public Button button1;
    public Button button2;

    public void Show(string title, string message, string buttonText1, string buttonText2 = "")
    {
        titleText.text = title;
        messageText.text = message;
        button1.GetComponentInChildren<Text>().text = buttonText1;
        button1.onClick.AddListener(Close);

        if (buttonText2 != "")
        {
            button2.gameObject.SetActive(true);
            button2.GetComponentInChildren<Text>().text = buttonText2;
            button2.onClick.AddListener(Close);
        }
        else
        {
            button2.gameObject.SetActive(false);
        }

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;

    public Image panelDialog;
    public GameObject faceDialog;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    

                public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("End of the conversation of course");
    }

    public void SetView()
    {
        faceDialog.SetActive(true);
        panelDialog.GetComponent<Image>().DOFillAmount(1,0.3f);
        StartCoroutine(OffView());
    }

    IEnumerator OffView()
    {
        yield return new WaitForSeconds(5);
        panelDialog.GetComponent<Image>().DOFade(0, 0.3f);
        faceDialog.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowMenu : MonoBehaviour
{
    public Image buttonPlay;
    public Image logoPlay;
    public Button ButtonMenu;

    private void Start()
    {
        ButtonMenu.interactable = false;
        buttonPlay.DOFade(0, 0);
        logoPlay.DOFade(0, 0);
    }

    private void OnMouseDown()
    {
        buttonPlay.DOFade(1, 2);
        logoPlay.DOFade(1, 2);
        StartCoroutine(MyCourtine());
    }

    IEnumerator MyCourtine()
    {
        yield return new WaitForSeconds(2);
        ButtonMenu.interactable = true;

    }
 
}

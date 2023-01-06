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
    public GameObject entryDoor;

    private void Start()
    {
        ButtonMenu.interactable = false;
        buttonPlay.DOFade(0, 0);
        logoPlay.DOFade(0, 0);
        entryDoor.GetComponent<MeshRenderer>().material.DOFade(0.5f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnMouseDown()
    {
        buttonPlay.DOFade(1, 2);
        logoPlay.DOFade(1, 2);
        Destroy(entryDoor);
        StartCoroutine(MyCourtine());
    }

    IEnumerator MyCourtine()
    {
        yield return new WaitForSeconds(2);
        ButtonMenu.interactable = true;

    }
 
}

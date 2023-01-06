using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ShowMenu : MonoBehaviour
{
    public Image logoPlay;
    public Button ButtonMenu;
    public GameObject entryDoor;

    private void Start()
    {
        logoPlay.DOFade(0, 0);
        entryDoor.GetComponent<MeshRenderer>().material.DOFade(0.5f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnMouseDown()
    {
        logoPlay.DOFade(1, 2);
        Destroy(entryDoor);
        StartCoroutine(MyCourtine());
    }

    IEnumerator MyCourtine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
}

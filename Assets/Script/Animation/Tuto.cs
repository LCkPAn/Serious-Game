using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

public class Tuto : MonoBehaviour
{
    [SerializeField] Image tuto;
    public static bool tutoOn = true;

    public void Start()
    {
        if (tutoOn)
        {
            tuto.transform.DOMoveX(100f, 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Restart);
            Debug.Log("Tuto");
            //tuto.transform.DOFade(0.1f, 1f).SetLoops(1, LoopType.Restart);
        }
    }


    public void Update()
    {
        if(!tutoOn)
        {
            tuto.enabled = false;
        }
    }
}

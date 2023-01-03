using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Option : MonoBehaviour
{

    public Image panel;
    

    private void Start()
    {
        panel.DOFade(0, 0);
       
    }


    public void PanelTween()
    {
        panel.DOFade(1, 1);
    }

    public void ExitTween()
    {
        panel.DOFade(0, 1);
    }
  
}

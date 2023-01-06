using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorAnim : MonoBehaviour
{
    public Animator animDoor;
    //[SerializeField] public Transform doorOpen;
   public void Start()
    {
        animDoor = GetComponent<Animator>();
    }

    public void OpenIsDoor()
    {
      animDoor.Play("Door");
    }

}

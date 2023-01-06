using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Touch : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Transform MenuSwipe;

    private Vector2 MovDirection = Vector2.zero;

    public static bool isSwipeActive = true; 


    private void Start()
    {
        isSwipeActive = true;
        foreach (WallMovable wall in Resources.FindObjectsOfTypeAll(typeof(WallMovable)) as WallMovable[])
        {
            wall.MoveWall();
        }

        foreach (WallMovableChimie wall in Resources.FindObjectsOfTypeAll(typeof(WallMovableChimie)) as WallMovableChimie[])
        {
            wall.MoveWall();
        }
    }

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    public void OnSwipe(string swipe)
    {
        if (isSwipeActive)
        {
            Tuto.tutoOn = false;
            RayCast.rayCastActive = false;
            StartCoroutine(ActiveRayCast()); 
            switch (swipe)
            {
                case "Left":
                    CameraManager.SwitchCameraRight();
                    MovDirection = Vector2.right;
                    break;

                case "Right":
                    CameraManager.SwitchCameraLeft();
                    MovDirection = Vector2.left;
                    break;
            }

            foreach (WallMovable wall in Resources.FindObjectsOfTypeAll(typeof(WallMovable)) as WallMovable[])
            {
                wall.MoveWall();
            }

            foreach (WallMovableChimie wall in Resources.FindObjectsOfTypeAll(typeof(WallMovableChimie)) as WallMovableChimie[])
            {
                wall.MoveWall();
            }
        }
    }

    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

    IEnumerator ActiveRayCast()
    {
        yield return new WaitForSeconds(1);
        RayCast.rayCastActive = true;
    }

}

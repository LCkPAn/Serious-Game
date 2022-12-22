using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class WallMovable : MonoBehaviour
{
 
    [SerializeField] CinemachineVirtualCamera cameras;
    [SerializeField] CinemachineVirtualCamera cameras2;



    public void MoveWall()
    {
        if (cameras == CameraManager.ActiveCamera || cameras2 == CameraManager.ActiveCamera)
        {
            transform.DOLocalMoveY(30f, 1f);
        }
        else 
        {
            transform.DOLocalMoveY(0f, 1f);
        }
    }
}

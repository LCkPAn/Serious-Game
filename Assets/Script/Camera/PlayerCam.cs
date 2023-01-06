using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera FirstView;
    [SerializeField] CinemachineVirtualCamera SecondView;
    [SerializeField] CinemachineVirtualCamera ThirdView;
    [SerializeField] CinemachineVirtualCamera FourView;

    private void OnEnable()
    {
     CameraManager.Register(FirstView);
     CameraManager.Register(SecondView);
     CameraManager.Register(ThirdView);
     CameraManager.Register(FourView);
     
     CameraManager.SwitchCamera(SecondView);
    }

    private void OnDisable()
    {
     CameraManager.Unregister(FirstView);
     CameraManager.Unregister(SecondView);
     CameraManager.Unregister(ThirdView);
     CameraManager.Unregister(FourView);
     
    }

   

}

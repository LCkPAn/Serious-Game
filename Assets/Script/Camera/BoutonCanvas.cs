using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCanvas : MonoBehaviour
{
    public void BackCamera()
    {
            CameraManager.SwitchCameraBack();
            Debug.Log("Salut");
    }
   
}

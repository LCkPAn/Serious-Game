using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    // Création une liste
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    //Valeur null
    public static CinemachineVirtualCamera ActiveCamera = null;
    public static CinemachineVirtualCamera InitCamera = null;


    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        //permet de checker la caméra active
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        Debug.Log(camera);
        if (camera != ActiveCamera)
        {
            InitCamera = ActiveCamera;
            ActiveCamera = camera;

            // fixe un priorité haute qui passe sur tout
            ActiveCamera.Priority = 10;

            foreach (CinemachineVirtualCamera c in cameras)
            {
                if (c != ActiveCamera && c.Priority != 0)
                {
                    c.Priority = 0;
                }
            }
        }
    }

    public static void SwitchCameraBack()
    {
        Touch.isSwipeActive = true;

        ActiveCamera.Priority = 0;
        ActiveCamera = InitCamera;

        ActiveCamera.Priority = 10;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != ActiveCamera && c.Priority != 0)
            {
                Debug.Log("coucou");
                c.Priority = 0;
            }
        }
    }

    public static void SwitchCameraRight()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (ActiveCamera == cameras[i])
            {
                if (i - 1 >= 0)
                {
                    Debug.Log(i);
                    ActiveCamera = cameras[i - 1];
                }
                else
                {
                    ActiveCamera = cameras[cameras.Count - 1];
                }

                // fixe un priorité haute qui passe sur tout
                ActiveCamera.Priority = 10;

                foreach (CinemachineVirtualCamera c in cameras)
                {
                    // On regarde si la camera actuel n'est pas celle sur laquel on veut basculer
                    if (c != ActiveCamera && c.Priority != 0)
                    {
                        c.Priority = 0;
                    }
                }
                return;
            }
        }
    }

    public static void SwitchCameraLeft()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (ActiveCamera == cameras[i])
            {
                if (i + 1 <= cameras.Count - 1)
                {
                    ActiveCamera = cameras[i + 1];
                }
                else
                {
                    ActiveCamera = cameras[0];
                }

                // fixe un priorité haute qui passe sur tout
                ActiveCamera.Priority = 10;

                foreach (CinemachineVirtualCamera c in cameras)
                {
                    // On regarde si la camera actuel n'est pas celle sur laquel on veut basculer
                    if (c != ActiveCamera && c.Priority != 0)
                    {
                        c.Priority = 0;
                    }
                }
                return;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        // J'ajoute cameras dans la liste camera
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        // Je retire cameras de la liste
        cameras.Remove(camera);
        ;
    }


}

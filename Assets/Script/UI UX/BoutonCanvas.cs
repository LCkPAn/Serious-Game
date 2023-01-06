using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoutonCanvas : MonoBehaviour
{
    public Button BackButton;
    public Button PauseButton;

    public bool showPauseButton = true;
    public bool showOptionButton = true;

    private void Start()
    {
        showPauseButton = !showPauseButton;
        BackButton.gameObject.SetActive(showPauseButton);
        PauseButton.gameObject.SetActive(showOptionButton);
    }

    public void ToggleButton()
    {
        showPauseButton = true;
        BackButton.gameObject.SetActive(showPauseButton);
        showOptionButton = false;
        PauseButton.gameObject.SetActive(showOptionButton);

    }

    public void BackCamera()
    {
            CameraManager.SwitchCameraBack();
            Debug.Log("Salut");
    }
   
}

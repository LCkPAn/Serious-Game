using UnityEngine;
using Cinemachine;
using System.Collections;


public class RayCast : MonoBehaviour
{
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private LayerMask NextLevelMask;
    private ItemsPickup itemsPickup;

    public MainMenu mainMenu;

    public static bool rayCastActive = true;
     
    private Transform _selection;

    void Update()
    {
        if(_selection != null)
        {
            _selection = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (rayCastActive)
            { 
                // création du raycast sur la caméra
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // contient l'objet touché par le raycast
                RaycastHit hit;
                // condition lu si touché par le raycast
                if (Physics.Raycast(ray, out hit, 200, wallMask))
                {
                    var selection = hit.transform;
                    Touch.isSwipeActive = false;
                    CameraManager.SwitchCamera(selection.transform.GetComponentInChildren<CinemachineVirtualCamera>());    
                    _selection = selection;
                }

                if (Physics.Raycast(ray, out hit, 10, objectMask))
                {
                    var selection = hit.transform;
                    Touch.isSwipeActive = false;
                    itemsPickup = hit.transform.gameObject.GetComponent<ItemsPickup>();
                    itemsPickup.Pickup();
                    _selection = selection;
                }

                if (Physics.Raycast(ray, out hit, 200, NextLevelMask))
                {
                    Debug.Log("Work");
                    var selection = hit.transform;
                    Touch.isSwipeActive = false;
                    mainMenu.StartGame();
                    _selection = selection;
                }
            }
        }
        
        
        
    }
}

using UnityEngine;
using Cinemachine;
using System.Collections;


public class RayCast : MonoBehaviour
{
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private LayerMask menuMask;
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private LayerMask NextLevelMask;
    [SerializeField] private LayerMask OpenDoor;

    private ItemsPickup itemsPickup;
    private Transform _selection;

    public MainMenu mainMenu;
    public BoutonCanvas boutonCanvas;

    public DoorAnim doorAnim;
    public Inventory inventory;

    public bool camNoSwitch = false;

    public bool NextLevel = false;

    public static bool rayCastActive = true;


    public void DontSwtich ()
    {
        camNoSwitch = false;
    }


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
                if (Physics.Raycast(ray, out hit, 200, wallMask) && camNoSwitch == false)
                {
                    var selection = hit.transform;
                    Touch.isSwipeActive = false;
                    boutonCanvas.ToggleButton();
                    camNoSwitch = true;
                    CameraManager.SwitchCamera(selection.transform.GetComponentInChildren<CinemachineVirtualCamera>());    
                    _selection = selection;
                }

                if (Physics.Raycast(ray, out hit, 200, menuMask))
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

                if (Physics.Raycast(ray, out hit, 8, NextLevelMask) && NextLevel)
                {
                    var selection = hit.transform;
                    Touch.isSwipeActive = false;
                    mainMenu.StartGame();
                    _selection = selection;
                }

                if (Physics.Raycast(ray, out hit, 10, OpenDoor) && inventory.activeDoor == true)
                {
                    doorAnim.OpenIsDoor();
                    inventory.shakeDoor.SetActive(false);
                    var selection = hit.transform;
                    Touch.isSwipeActive = false;
                    _selection = selection;
                    StartCoroutine(DontSkipLevel());
                }
            }
        }
        
        
        
    }

    IEnumerator DontSkipLevel()
    {
        yield return new WaitForSeconds(0.3f);
        NextLevel = true;
    }
}

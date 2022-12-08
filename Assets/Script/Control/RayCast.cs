using UnityEngine;
using Cinemachine;
using System.Collections;


public class RayCast : MonoBehaviour
{
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private LayerMask objectMask;
    private ItemsPickup itemsPickup;

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
                Touch.isSwipeActive = false;
                // cr�ation du raycast sur la cam�ra
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // contient l'objet touch� par le raycast
                RaycastHit hit;
                // condition lu si touch� par le raycast
                if (Physics.Raycast(ray, out hit, 200, wallMask))
                {
                    var selection = hit.transform;
                    CameraManager.SwitchCamera(selection.transform.GetComponentInChildren<CinemachineVirtualCamera>());    
                    _selection = selection;
                }

                if (Physics.Raycast(ray, out hit, 10, objectMask))
                {
                    var selection = hit.transform;
                    Debug.Log(itemsPickup);
                    itemsPickup = hit.transform.gameObject.GetComponent<ItemsPickup>();
                    itemsPickup.Pickup();
                    _selection = selection;
                }
            }
        }
        
        
        
    }
}

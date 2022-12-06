using UnityEngine;
using Cinemachine;


public class RayCast : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection;
    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            _selection = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // cr�ation du raycast sur la cam�ra
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // contient l'objet touch� par le raycast
            RaycastHit hit;

            // condition lu si touch� par le raycast
            if (Physics.Raycast(ray, out hit))
            {
               
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    Debug.Log(selection.gameObject);
                    CameraManager.SwitchCamera(selection.transform.GetComponentInChildren<CinemachineVirtualCamera>());
                }
                _selection = selection;
               
            }
        }
        

        
    }
}

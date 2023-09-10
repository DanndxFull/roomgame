using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask layerToGrab, layerToZoom;
    [SerializeField] private float rangeToInteract;
    [SerializeField] private Camera camToZoom;
    [SerializeField] private Transform pointToInteract;
    [SerializeField] private ControllerObject controllerObject;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCamera playerCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InteractionIn();
        }
    }

    public void InteractionIn()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, rangeToInteract, layerToGrab))
        {
            //Debug.Log("Di con algo");
            camToZoom.enabled = true;
            hit.transform.position = pointToInteract.position;
            //Debug.Log(layerToZoom.value);
            hit.transform.gameObject.layer = 12;
            hit.transform.GetChild(0).gameObject.layer = 12;
            playerMovement.enabled = false;
            playerCam.enabled = false;
            controllerObject.enabled = true;
            controllerObject.focusObject = hit.transform;
            controllerObject.isHoolding = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void InteractionOut()
    {
        camToZoom.enabled = false;        
        playerMovement.enabled = true;
        playerCam.enabled = true;
        controllerObject.enabled = false;
        controllerObject.focusObject = null;
        controllerObject.isHoolding = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

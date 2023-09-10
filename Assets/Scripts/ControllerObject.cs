using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerObject : MonoBehaviour
{
    public Camera cam;
    public Transform focusObject;
    public Transform orientation;
    public float sensX;
    public float sensY;


    public bool isHoolding;


    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    private float zoom;
    [SerializeField] private float zoomMultiplier = 50;
    [SerializeField] private float minZoom = 25;
    [SerializeField] private float maxZoom = 60;
    private float velocityZoom = 0;
    [SerializeField] private float smoothTime = 0.25f;
    [SerializeField] private PlayerInteraction playerInteraction;

    private void Start()
    {
        zoom = cam.fieldOfView;
    }


    private void Update()
    {
        if (isHoolding)
        {
            if (Input.GetMouseButton(0))
            {
                mPosDelta = Input.mousePosition - mPrevPos;
                focusObject.Rotate(cam.transform.up, -Vector3.Dot(mPosDelta, cam.transform.right)*sensX, Space.World);
                focusObject.Rotate(cam.transform.right, Vector3.Dot(mPosDelta, cam.transform.up)*sensY, Space.World);
            }

            mPrevPos = Input.mousePosition;

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            zoom -= scroll * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, zoom, ref velocityZoom, smoothTime);
            if (Input.GetMouseButtonDown(1))
            {
                focusObject.gameObject.layer = 11;
                focusObject.transform.GetChild(0).gameObject.layer = 11;
                focusObject.position = orientation.transform.position + (orientation.transform.forward*4);
                focusObject.rotation = Quaternion.identity;
                playerInteraction.InteractionOut();
                isHoolding = false;
            }
        }
    }
}

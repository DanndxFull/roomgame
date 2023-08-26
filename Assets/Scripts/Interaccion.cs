using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    private Transform camara;
    public float rayDistance;
    void Start()
    {
        camara = transform.Find("Camera");
    }

    void Update()
    {
        Debug.DrawRay(camara.position, camara.forward * rayDistance, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(camara.position, camara.forward, out hit, rayDistance, LayerMask.GetMask("interaccion"))){
            Debug.Log(hit.transform.name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionCamara : MonoBehaviour
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
        
        if(Input.GetButtonDown("Interaccion")){
            RaycastHit hit;
            if(Physics.Raycast(camara.position, camara.forward, out hit, rayDistance, LayerMask.GetMask("interaccion"))){
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Interacciones>().Interact();
            }
        }
    }
}

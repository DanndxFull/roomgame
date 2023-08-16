using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private Transform camara;
    public Vector2 sensibility;
    //Se modifica en el inspector - Script
    //Valores de prueba 5 - 5

    void Start()
    {
        camara = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.none;
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        if(horizontal != 0){
            transform.Rotate(Vector3.up * horizontal * sensibility.x);
        }
        if(vertical != 0){
            //camara.Rotate(Vector3.left * vertical * sensibility.y);
            float angle = (camara.localEulerAngles.x - vertical * sensibility.y + 360) % 360;
            if(angle > 180){
                angle -= 360;
            }
            angle = Mathf.Clamp(angle, -80, 80);
            camara.localEulerAngles = Vector3.right * angle;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        // Asignar la posición de la cámara a la posición del objeto
        if (cameraPosition != null)
        {
            // Mantener la posición del objeto pero aplicar la rotación de la cámara
            transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, cameraPosition.position.z);
            transform.rotation = cameraPosition.rotation;
        }
        else
        {
            Debug.LogWarning("La posición de la cámara no está asignada en el script MoveCamera.");
        }
    }
}

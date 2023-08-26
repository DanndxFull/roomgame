using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : Interacciones
{
    public override void Interact(){
        base.Interact();
        transform.Rotate(Vector3.up * 90);
    }
}

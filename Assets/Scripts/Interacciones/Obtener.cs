using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtener : Interacciones
{
    public override void Interact(){
        base.Interact();
        Destroy(gameObject);
    }

}

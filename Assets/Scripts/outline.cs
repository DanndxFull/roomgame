using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outline : MonoBehaviour
{
    public Transform playerTrans;
    public Transform objectoTrans;
    public Material resaltado;

    // Start is called before the first frame update
    void Start()
    {
        resaltado.SetFloat("_Scale", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerTrans.position, objectoTrans.position) <3 )
        {
            resaltado.SetFloat("_Scaler", 1.03f);
        }
        else
        {
            resaltado.SetFloat("_Scaler", 0f);
        }
    }
}

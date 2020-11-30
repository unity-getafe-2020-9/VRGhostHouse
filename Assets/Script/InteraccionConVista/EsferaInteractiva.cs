using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaInteractiva : ElementoInteractivo
{
    public float fuerza;
    public override void DoAction()
    {
        Vector3 direction = transform.position - Camera.main.transform.position;
        GetComponent<Rigidbody>().AddForce(direction * fuerza);
    }
}

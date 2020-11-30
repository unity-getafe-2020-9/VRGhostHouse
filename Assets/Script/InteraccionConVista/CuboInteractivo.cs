using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboInteractivo : ElementoInteractivo
{
    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public override void DoAction()
    {
        material.color = Color.red;
        actionPerformed = true;
    }
}

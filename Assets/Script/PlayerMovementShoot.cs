using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementShoot : MonoBehaviour
{
    public float yAccelerationTarget = 0.5f;
    public GameObject prefabProyectil;
    public Transform puntoLanzamiento;
    public float fuerzaLamzamiento;

    private float yAcceleration;    
    void Update()
    {
        yAcceleration = Input.acceleration.y;
        if (yAcceleration > yAccelerationTarget)
        {
            Disparar();
        }
    }
    private void Disparar()
    {
        GameObject proyectil = Instantiate(
            prefabProyectil,
            puntoLanzamiento.transform.position,
            puntoLanzamiento.transform.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(puntoLanzamiento.transform.forward * fuerzaLamzamiento);
    }
}

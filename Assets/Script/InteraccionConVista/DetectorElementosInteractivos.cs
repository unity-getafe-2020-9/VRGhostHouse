using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectorElementosInteractivos : MonoBehaviour
{
    public GameObject playerCamera;
    public float maxDetectionDistance;
    public float tiempoHastaAccion;
    public Image imagenTargetDetection;


    private bool targetLocalizado = false;
    private float contadorTiempo = 0;
    private GameObject currentTarget;
    void Update()
    {
        RaycastHit hitInfo;
        Ray rayoVision = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        //Determina si el raycast impacta sobre un elemento interactivo o no.
        if (Physics.Raycast(rayoVision, out hitInfo, maxDetectionDistance))
        {
            if (hitInfo.transform.gameObject.GetComponent<ElementoInteractivo>())
            {
                targetLocalizado = true;
            } else
            {
                targetLocalizado = false;
            }
        } else
        {
            targetLocalizado = false;
        }

        //Sólo si impacta con un elemento interactivo y si su acción no ha sido realizada, continua.
        if (targetLocalizado && !hitInfo.transform.gameObject.GetComponent<ElementoInteractivo>().actionPerformed)
        {
            if (contadorTiempo > 0)
            {
                if (currentTarget != hitInfo.transform.gameObject)
                {
                    contadorTiempo = 0;
                    currentTarget = hitInfo.transform.gameObject;
                }
            } else
            {
                currentTarget = hitInfo.transform.gameObject;
            }
            contadorTiempo += Time.deltaTime;
            if (contadorTiempo >= tiempoHastaAccion)
            {
                hitInfo.transform.gameObject.GetComponent<ElementoInteractivo>().DoAction();
                contadorTiempo = 0;
            }
        } else
        {
            contadorTiempo = 0;
        }
        imagenTargetDetection.fillAmount = contadorTiempo / tiempoHastaAccion;
    }



    /// <summary>
    /// Determina si se puesto la vista en un objeto con un componente de tipo ElementoInteractivo
    /// e invoca al método DoAction inmediatamente.
    /// </summary>
    private void DeteccionInmediata()
    {
        RaycastHit hitInfo;
        Ray rayoVision = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(rayoVision, out hitInfo, maxDetectionDistance))
        {
            if (hitInfo.transform.gameObject.GetComponent<ElementoInteractivo>())
            {
                hitInfo.transform.gameObject.GetComponent<ElementoInteractivo>().DoAction();
            }
        }
    }
}

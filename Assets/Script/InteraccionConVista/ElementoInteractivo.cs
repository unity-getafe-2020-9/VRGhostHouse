using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementoInteractivo : MonoBehaviour
{
    public bool actionPerformed = false;
    public abstract void DoAction();
}

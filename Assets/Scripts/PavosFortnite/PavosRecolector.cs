using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavosRecolector : MonoBehaviour
{
    public void  OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("Pavo"))
        {
            PavosJugador.Instance.numPavos++;
        }
    }
}

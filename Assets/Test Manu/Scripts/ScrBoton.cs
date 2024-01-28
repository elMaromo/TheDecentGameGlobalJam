using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBoton : MonoBehaviour
{
    public Animator puertaAnimator;

    public string nombreParametroAnimacion = "pulsado";


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            puertaAnimator.SetBool(nombreParametroAnimacion, true);
        }
    }

}
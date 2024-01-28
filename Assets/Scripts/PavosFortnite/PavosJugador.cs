using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PavosJugador : MonoBehaviour
{
    // If there is an instance, and it's not me, delete myself.

    public static PavosJugador Instance { get; private set; }
    public int numPavos;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void  OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("Pavo"))
        {
            numPavos++;
            Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }

    }

}

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
    public TextMeshProUGUI pavosText;

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
    private void Start()
    {
        if (pavosText == null)
        {
            Debug.LogError("Asigna el objeto Text para mostrar la cantidad de pavos en el Inspector.");
        }
        else
        {
            ActualizarInterfaz();
        }
    }

    public void  OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("Pavo"))
        {
            numPavos++;
            Destroy(other.gameObject);
            ActualizarInterfaz();
        }

    }
    private void ActualizarInterfaz()
    {
        pavosText.text = "Pavos: " + numPavos.ToString();
    }
}

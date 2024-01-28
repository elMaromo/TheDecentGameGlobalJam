using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTP : MonoBehaviour
{
    [SerializeField] Transform nuevaPosicion;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deathzone"))
        {
           
            transform.position = nuevaPosicion.position;
            
        }
    }
}

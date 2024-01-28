using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrDoor : MonoBehaviour
{
    private Animator animator;
    private bool pulsar = false;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener el componente Animator del objeto
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("El objeto no tiene un componente Animator.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si pulsar es verdadero y la animación no está en reproducción
        if (pulsar)
        {
            // Establecer la variable 'pulsar' en el Animator como verdadera
            animator.SetBool("pulsar", true);
        }
    }
}


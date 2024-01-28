using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class niniosScript : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    public void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void  OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("Player"))
        {
            audio.Play();
        }
    }


    public void  OnTriggerExit(Collider other)
    {
        if( other.gameObject.CompareTag("Player"))
        {
            audio.Stop();
        }
    }
}

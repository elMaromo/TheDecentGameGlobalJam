using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MelenitasDev;
using MelenitasDev.SoundsGood;

public class ScrCar : MonoBehaviour
{
    public ParticleSystem particleSystem;  // Asigna el sistema de partículas desde el Inspector

    void Start()
    {
        Sound sound = new Sound(SFX.coche);
        sound.SetFadeOut(3);
        sound.Play();
    }

     void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");

        if (other.CompareTag("Tubo"))
        {
            Debug.Log("Collided with Tubo");
            particleSystem.Play();
            Sound sound = new Sound(SFX.coche);
            sound.SetFadeOut(3);
            sound.Play();
        }
    }
}

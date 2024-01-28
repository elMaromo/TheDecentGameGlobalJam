using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MelenitasDev;
using MelenitasDev.SoundsGood;

public class ScrCar : MonoBehaviour
{
    public ParticleSystem particleSystem;  

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("kxao"))
        {
            Sound kxao = new Sound(SFX.kxao);
            kxao.Play();
        }
        if (other.CompareTag("Tubo2"))
        {
            Sound gota = new Sound(SFX.gota);
            gota.SetVolume(250f);
            gota.Play();
            Sound sound = new Sound(SFX.coche);
            sound.Play();
            sound.Stop(3.3f);
        }
        if (other.CompareTag("Tubo"))
        {
            particleSystem.Play();
            Sound explosion = new Sound(SFX.explosion);
            explosion.SetVolume(0.5f);
            explosion.SetFadeOut(0.1f);
            explosion.Play();
            
        } 
    }
}

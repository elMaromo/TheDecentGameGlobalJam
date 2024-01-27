using UnityEngine;

namespace Scenes.Level4.Scripts.PlayerMovement
{
    public class ChangeAuidioSprint : MonoBehaviour
    {
        public AudioClip RuningSound;

        private AudioClip walkingSound;
        private AudioSource audi;

        void Start()
        {
            audi = GetComponent<AudioSource>();
            walkingSound = audi.clip;
        }

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift))
            {
                audi.clip = RuningSound;
                audi.Play();
            }

            if (UnityEngine.Input.GetKeyUp(KeyCode.LeftShift))
            {
                audi.clip = walkingSound;
                audi.Play();
            }
        }
    }
}

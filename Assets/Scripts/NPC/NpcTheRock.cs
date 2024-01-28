using System;
using MelenitasDev.SoundsGood;
using UnityEngine;

namespace NPC
{
    public class NpcTheRock : Npc
    {
        private Camera _camera;
        private Sound _theRockSound;
        
        private void Start()
        {
            _theRockSound = new Sound(SFX.TheRock);
            _camera = Camera.main;
        }

        protected override void Update()
        {
            base.Update();
            CheckAngle();
        }

        private void CheckAngle()
        {
            Ray rayo = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
            RaycastHit hit;

            // Distancia máxima para la intersección del rayo
            float distanciaMaxima = 100f;

            // Verifica si el rayo impacta con el collider del NPC
            if (!Physics.Raycast(rayo, out hit, distanciaMaxima)) return;
            if (hit.collider.name.Equals(this.name))
            {
                if(_theRockSound.Playing)return;
                _theRockSound.Play();
            }
        }
    }
}
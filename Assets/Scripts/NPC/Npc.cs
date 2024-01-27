using System;
using UnityEngine;

namespace NPC
{
    public class Npc : MonoBehaviour
    {
        protected Transform myTransform;
        protected Transform player;

        private void Awake()
        {
            myTransform = transform;
        }
        
        public void Configure(Transform player)
        {
            this.player = player;
        }

        protected virtual void Update()
        {
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            var directionToPlayer = player.position - myTransform.position;
            directionToPlayer.y = 0;
            var rotation = Quaternion.LookRotation(directionToPlayer);
            myTransform.rotation = rotation * Quaternion.Euler(90, 0, 0);
        }
    }
}
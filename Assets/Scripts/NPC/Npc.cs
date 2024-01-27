using System;
using UnityEngine;

namespace NPC
{
    public class Npc : MonoBehaviour
    {
        private Transform _myTransform;
        private Transform _player;

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(Transform player)
        {
            _player = player;
        }

        private void Update()
        {
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            var directionToPlayer = _player.position - _myTransform.position;
            directionToPlayer.y = 0;
            var rotation = Quaternion.LookRotation(directionToPlayer);
            _myTransform.rotation = rotation * Quaternion.Euler(90, 0, 0);
        }
    }
}
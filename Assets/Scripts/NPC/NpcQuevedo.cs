using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace NPC
{
    public class NpcQuevedo : Npc
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform[] _pathPoints;

        private int _pathPointIndex;
        private bool _isPlayerInSight;

        private void Start()
        {
            _isPlayerInSight = false;
            _pathPointIndex = 0;
        }

        protected override void Update()
        {
            base.Update();
            CheckIfPlayerIsInSight();
            
            if (_isPlayerInSight)
            {
                FollowPlayer();
                return;
            }

            FollowPathPoints();
        }

        private void FollowPathPoints()
        {
            if (_agent.remainingDistance > _agent.stoppingDistance) return;

            _pathPointIndex = Random.Range(0, _pathPoints.Length);
            _agent.SetDestination(_pathPoints[_pathPointIndex].position);
        }

        private void FollowPlayer()
        {
            _agent.SetDestination(player.transform.position);
        }

        private void CheckIfPlayerIsInSight()
        {
            
        }
    }
}
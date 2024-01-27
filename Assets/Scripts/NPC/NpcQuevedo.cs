using System;
using MelenitasDev.SoundsGood;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace NPC
{
    public class NpcQuevedo : Npc
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform[] _pathPoints;
        [SerializeField] private float _pursuitSpeed;
        [SerializeField] private float _randomSoundCooldown;
        [SerializeField] private float _quedateSoundCooldown;
        
        private int _pathPointIndex;
        private bool _isPlayerInSight;

        private float _currentRandomSoundCooldown;
        private float _currentQuedateSoundCooldown;

        private void Start()
        {
            _isPlayerInSight = false;
            _pathPointIndex = 0;
            _currentRandomSoundCooldown = 0;
            _currentQuedateSoundCooldown = 0;
        }

        protected override void Update()
        {
            base.Update();
            RefreshCooldowns();
            CheckIfPlayerIsInSight();
            
            if (_isPlayerInSight)
            {
                FollowPlayer();
                PlayQuedateSfx();
                return;
            }

            FollowPathPoints();
            PlayRandomSfx();
        }

        private void RefreshCooldowns()
        {
            _currentQuedateSoundCooldown -= Time.deltaTime;
            _currentQuedateSoundCooldown = Mathf.Clamp(_currentQuedateSoundCooldown, 0f, _quedateSoundCooldown);
            _currentRandomSoundCooldown -= Time.deltaTime;
            _currentRandomSoundCooldown = Mathf.Clamp(_currentRandomSoundCooldown, 0f, _randomSoundCooldown);
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
            if(_isPlayerInSight) return;
            var directionToPlayer = player.position - myTransform.position;
            var ray = new Ray(myTransform.position, directionToPlayer);
            RaycastHit hit;

            // Realiza el raycast
            if (!Physics.Raycast(ray, out hit, Mathf.Infinity)) return;
            if (hit.transform != player) return;

            _isPlayerInSight = true;
            _agent.speed = _pursuitSpeed;

            PlayQuedateSfx();
        }

        private void PlayQuedateSfx()
        {
            if(_currentQuedateSoundCooldown > 0) return;
            _currentQuedateSoundCooldown = _quedateSoundCooldown;
            var quedateSfx = new Sound(SFX.Quevedo);
            quedateSfx.SetPitch(0.75f);
            quedateSfx.SetVolume(.5f);
            quedateSfx.Play();
        }

        private void PlayRandomSfx()
        {
            if(_currentRandomSoundCooldown > 0) return;
            _currentRandomSoundCooldown = _randomSoundCooldown;
            var randomSfx = new Sound(SFX.QuevedoEffect);
            randomSfx.SetRandomClip(true);
            randomSfx.SetPitch(0.85f);
            randomSfx.SetVolume(.25f);
            randomSfx.Play();
        }
    }
}
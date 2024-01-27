using UnityEngine;

namespace NPC
{
    public class NpcsInstaller : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Npc[] _people;

        private void Awake()
        {
            foreach (var person in _people)
            {
                person.Configure(_player);
            }
        }
    }
}
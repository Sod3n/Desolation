using System;
using Canopy.Events;
using Desolation.Scripts.Entity.Systems;
using UnityEngine;
using Zenject;

namespace Desolation.Scripts.Entity.Passives
{
    public class HealOnEvent : MonoBehaviour
    {
        [Inject] private HealSystem _healSystem;
        
        [SerializeField] private EventRef _event;
        [SerializeField] private float _amount;

        private void Awake()
        {
            _event.Initialize();
            _event += () => _healSystem.PerformHeal(_amount);
        }
    }
}
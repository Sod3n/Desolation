using System;
using Canopy.Events;
using UnityEngine;

namespace Desolation.Scripts.Entity.Passives
{
    public class HitCounter : MonoBehaviour
    {
        [SerializeField] private EventRef _event;
        [SerializeField] private int _hitCountToAchieve;
        
        public event Action OnAchieved;

        private int _currentHitCount = 0;
        
        private void Awake()
        {
            _event.Initialize();
            _event += UpdateHits;
        }

        private void UpdateHits()
        {
            _currentHitCount++;

            if (_currentHitCount < _hitCountToAchieve) return;

            _currentHitCount = 0;
            OnAchieved?.Invoke();
        }
    }
}
using System;
using HierarchicalStatePattern;
using UnityEngine;

namespace Desolation.StatePattern
{
    public class Timer : StateBehaviour
    {
        [SerializeField] private float _time;

        public event Action OnEnd;

        private float _currentTime = 0;
        private bool _invoked = false;

        public override void OnEnter()
        {
            _currentTime = 0;
            _invoked = false;
        }

        private void FixedUpdate()
        {
            _currentTime += Time.fixedDeltaTime;

            if (_currentTime >= _time && !_invoked)
            {
                OnEnd?.Invoke();
                _invoked = true;
            }
        }
    }
}
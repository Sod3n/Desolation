using System;
using System.Linq;
using HierarchicalStatePattern;
using UnityEngine;

namespace Desolation.StatePattern
{
    public class TrackDistanceToTarget : StateBehaviour
    {
        [SerializeField] private Targets _targets;
        [SerializeField] private float _triggerDistance;
        [SerializeField] private bool _startFromGreaterDistance;

        private float _initDistance;

        public event Action OnTrigger; 

        public override void OnEnter()
        {
            _initDistance = _targets.Visible.First().DistanceLength;
        }

        private void FixedUpdate()
        {
            var distance = _targets.Visible.First().DistanceLength;
            
            if ((_startFromGreaterDistance && distance < _triggerDistance))
                OnTrigger?.Invoke();
            
            if ((!_startFromGreaterDistance && distance > _triggerDistance)) 
                OnTrigger?.Invoke();
        }
    }
}

using Desolation.StatePattern;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Overcharge : StateBehaviour
    {
        [SerializeField] private Charge _charge;
        [SerializeField] private float _overchargeThreshold;

        public event Action OnOvercharged;

        private void FixedUpdate()
        {
            
            if (_charge.Power >= _overchargeThreshold)
            {
                Debug.Log("Overcharge");
                OnOvercharged.Invoke();
            }
        }
    }
}

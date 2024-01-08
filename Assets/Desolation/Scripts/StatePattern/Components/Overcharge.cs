using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Overcharge : IStateComponent.IFixedTickable
    {
        private Charge.Power _power;
        private Settings _settings;

        public Overcharge(Settings settings, Charge.Power power)
        {
            _power = power;
            _settings = settings;
        }

        public event Action OnOvercharged;

        public void FixedTick()
        {
            if(_power.Value >= _settings.OverchargeThreshold)
            {
                Debug.Log("Overcharge");
                OnOvercharged.Invoke();
            }
        }

        [Serializable]
        public class Settings
        {
            public float OverchargeThreshold;
        }
    }
}

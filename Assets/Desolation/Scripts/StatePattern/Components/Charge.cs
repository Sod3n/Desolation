using Cysharp.Threading.Tasks;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Charge :
        IStateComponent.IEnterable,
        IStateComponent.IFixedTickable
    {
        private Power _power;
        private Settings _settings;

        public Charge(Power power, Settings settings)
        {
            _power = power;
            _settings = settings;
        }

        public void OnEnter()
        {
            _power.Value = 0;
        }

        public void FixedTick()
        {
            _power.Value += _settings.PowerIncreasePerSecond * Time.deltaTime;
        }

        public class Actions
        {
            public Action OnChargeInterapted;
        }

        public class Power
        {
            public float Value { get; set; }
        }

        [Serializable]
        public class Settings
        {
            public float PowerIncreasePerSecond;
        }
    }
}

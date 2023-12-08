using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class Charge :
        IComponent.IEnterable, IInitializable,
        IComponent.ITickable
    {
        private Events _events;
        private Power _power;
        private Settings _settings;

        public Charge(Events events, Power power, Settings settings)
        {
            _events = events;
            _power = power;
            _settings = settings;
        }

        public void Initialize()
        {
            _events.EndCharge += () => { IsDone = true; };
        }

        private bool _chargingStarted;

        public bool IsDone { get; set; }

        public void OnStateEnter()
        {
            IsDone = false;
            _chargingStarted = false;
            _power.Value = 0;
        }

        

        public void Tick()
        {
            if (_chargingStarted) return;

            _chargingStarted = true;
            _ = IncreacePower();
        }

        private async UniTask IncreacePower()
        {
            while (!IsDone)
            {
                _power.Value += _settings.PowerIncreasePerSecond * Time.deltaTime;
                await UniTask.NextFrame();
            }
        }

        public class Events
        {
            public Action EndCharge = () => { };
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

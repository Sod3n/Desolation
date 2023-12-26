using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class ChangeStateOnOvercharge : StateChanger, IComponent.IFixedTickable
    {
        private Charge.Power _power;
        private Settings _settings;
        public ChangeStateOnOvercharge(
            Settings settings, State.Identificator to, 
            LazyInject<ISkill> owner, Charge.Power power) 
            : base(to, owner)
        {
            _power = power;
            _settings = settings;
        }

        public void FixedTick()
        {
            if(_power.Value >= _settings.OverchargeThreshold)
            {
                ChangeState();
            }
        }

        [Serializable]
        public class Settings
        {
            public float OverchargeThreshold;
        }
    }
}

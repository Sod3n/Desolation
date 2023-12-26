using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class Cooldown : IComponent.IEnterable
    {
        private Settings _settings;
        private LazyInject<ISkill> _owner;

        public Cooldown(Settings settings, LazyInject<ISkill> owner)
        {
            _settings = settings;
            _owner = owner;
        }
        private UniTask _task;
        private float _currentValue;

        public bool IsDone { get; set; } = true;

        public void OnStateEnter()
        {
            if (!_task.Status.IsCompleted())
            {
                _owner.Value.Break();

                Debug.Log("In cooldown " + _currentValue);
                return;
            }

            _currentValue = _settings.Value;
            _task = DecreaseCurrentValue();
        }

        private async UniTask DecreaseCurrentValue()
        {
            while (_currentValue > 0)
            {
                _currentValue -= Time.deltaTime;
                await UniTask.NextFrame();
            }
        }

        [Serializable]
        public class Settings
        {
            public float Value;
        }
    }
}

using Cysharp.Threading.Tasks;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Cooldown : IStateComponent.IEnterable
    {
        private Settings _settings;
        private LazyInject<IStateController> _controller;

        public Cooldown(Settings settings, LazyInject<IStateController> controller)
        {
            _settings = settings;
            _controller = controller;
        }
        private UniTask _task;
        private float _currentValue;

        public event Action OnEnteredWhenInColldown = () => { };

        public void OnEnter()
        {
            if (!_task.Status.IsCompleted())
            {
                OnEnteredWhenInColldown.Invoke();

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

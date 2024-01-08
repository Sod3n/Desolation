using Cysharp.Threading.Tasks;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class WaitSeconds : IStateComponent.IEnterable, IStateComponent.IFixedTickable
    {
        private Settings _settings;

        public WaitSeconds(Settings settings)
        {
            _settings = settings;
        }

        public event Action OnCompleted;
        private UniTask? _task;

        public void FixedTick()
        {
            if (_task != null && _task.Value.Status.IsCompleted())
            {
                _task = null;
                OnCompleted.Invoke();
            }
        }

        public void OnEnter()
        {
            _task = UniTask.WaitForSeconds(_settings.Seconds);
        }

        [Serializable]
        public class Settings
        {
            public float Seconds;
        }
    }
}

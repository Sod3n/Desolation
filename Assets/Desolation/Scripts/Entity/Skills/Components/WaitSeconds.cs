using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class WaitSeconds : IComponent.IEnterable, IComponent.IFixedTickable
    {
        private Settings _settings;

        public WaitSeconds(Settings settings)
        {
            _settings = settings;
        }
        private UniTask? _task;

        public bool IsDone { get; set; }

        public void FixedTick()
        {
            if (_task != null && _task.Value.Status.IsCompleted())
            {
                _task = null;
                IsDone = true;
            }

            if(!IsDone && _task == null)
            {
                _task = UniTask.WaitForSeconds(_settings.Seconds);
            }
        }

        public void OnStateEnter()
        {
            IsDone = false;
        }

        [Serializable]
        public class Settings
        {
            public float Seconds;
        }
    }
}

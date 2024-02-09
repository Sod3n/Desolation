using Cysharp.Threading.Tasks;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Cooldown : StateBehaviour
    {
        [SerializeField] private float _time;

        private UniTask _task;
        private float _remainingTime;

        public UniTask Task { get { return _task; } }
        public float RemainingTime { get => _remainingTime; }

        public override void OnEnter()
        {
            _remainingTime = _time;
            _task = DecreaseCurrentValue();
        }

        private async UniTask DecreaseCurrentValue()
        {
            while (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
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

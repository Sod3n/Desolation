using Desolation.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Desolation.Entity.Antaine
{
    public class TrackMouseInput : Zenject.ITickable
    {
        private LookIn.Direction _lookDirection;
        private Transform _transform;
        private Input _input;

        public TrackMouseInput(LookIn.Direction lookDirection, Transform transform, Input input)
        {
            _lookDirection = lookDirection;
            _transform = transform;
            _input = input;
        }

        public void Tick()
        {
            _lookDirection.Value = (_input.WorldAimPoint - _transform.position);
            _lookDirection.Value.y = 0;
            _lookDirection.Value = _lookDirection.Value.normalized;
        }
    }
}

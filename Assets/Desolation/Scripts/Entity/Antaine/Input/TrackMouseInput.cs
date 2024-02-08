using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Desolation.Entity.Antaine
{
    public class TrackMouseInput : Zenject.ITickable
    {
        private Vector3 _lookDirection;
        private Transform _transform;
        private Input _input;

        public void Tick()
        {
            _lookDirection = (_input.WorldAimPoint - _transform.position);
            _lookDirection.y = 0;
            _lookDirection = _lookDirection.normalized;
        }
    }
}

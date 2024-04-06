using System;
using Desolation.StatePattern;
using UnityEngine;

namespace Desolation.Scripts.StatePattern
{
    public class SaveDirection : Direction
    {
        [SerializeField] private Direction _direction;

        // OnEnter
        private void OnEnable()
        {
            _value = _direction.Value;
        }
    }
}
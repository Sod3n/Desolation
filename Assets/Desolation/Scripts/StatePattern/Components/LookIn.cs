using Desolation.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class LookIn : IStateComponent.IFixedTickable
    {
        private Direction _direction;
        private Transform _transform;

        public LookIn(Direction direction, Transform transform)
        {
            _direction = direction;
            _transform = transform;
        }

        public void FixedTick()
        {
            _transform.rotation = Quaternion.LookRotation(_direction.Value);
        }

        public class Direction
        {
            public Vector3 Value;
        }
    }
}

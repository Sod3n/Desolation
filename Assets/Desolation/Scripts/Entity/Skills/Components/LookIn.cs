using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class LookIn : IComponent.IFixedTickable
    {
        private Direction _direction;
        private Transform _transform;

        public LookIn(Direction direction, Transform transform)
        {
            _direction = direction;
            _transform = transform;
        }

        public bool IsDone { get; set; } = true;

        public void FixedTick()
        {
            _transform.rotation = Quaternion.LookRotation(_direction.Value);
            IsDone = true;
        }

        public class Direction
        {
            public Vector3 Value;
        }
    }
}

using Desolation.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using HierarchicalStatePattern;

namespace Desolation.StatePattern
{
    public class LookIn : StateBehaviour
    {
        [Inject] private Transform _transform;

        [SerializeField]private Vector3 _direction;
        

        public void FixedTick()
        {
            _transform.rotation = Quaternion.LookRotation(_direction);
        }
    }
}

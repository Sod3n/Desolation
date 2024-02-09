using HierarchicalStatePattern;
using log4net.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Desolation.StatePattern
{
    public class MoveForward : StateBehaviour
    {
        [Inject] private Rigidbody _rigidbody;

        [SerializeField] private float _unitsPerSecond;

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(
                _rigidbody.transform.position + _rigidbody.transform.forward * _unitsPerSecond * Time.fixedDeltaTime);
        }
    }
}

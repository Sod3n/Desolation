using HierarchicalStatePattern;
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
            /*var raw = _rigidbody.transform.forward * _unitsPerSecond;
            var sign = raw.normalized;
            var vel = raw - _rigidbody.velocity;
            var velSign = vel.normalized;

            if (Math.Abs(Mathf.Ceil(sign.x) - Mathf.Ceil(velSign.x)) > 0.001) vel.x *= 0;
            if (Math.Abs(Mathf.Ceil(sign.y) - Mathf.Ceil(velSign.y)) > 0.001) vel.y *= 0;
            if (Math.Abs(Mathf.Ceil(sign.z) - Mathf.Ceil(velSign.z)) > 0.001) vel.z *= 0;
            
            _rigidbody.AddForce(vel, ForceMode.VelocityChange);*/

            _rigidbody.velocity = _rigidbody.transform.forward * (_unitsPerSecond);

        }

        public override void OnExit()
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class RotateInDirection : MonoBehaviour
    {
        [Inject] private Rigidbody _rigidbody;
        [SerializeField] private Direction _direction;
        [SerializeField] private float _magicRotationSpeed = 1f;



        private void FixedUpdate()
        {
            if(_direction.Value.sqrMagnitude == 0) return;

            Quaternion rotation = Quaternion.LookRotation(_direction.Value, Vector3.up);
            rotation = Quaternion.Lerp(
                _rigidbody.rotation, 
                rotation, 
                _magicRotationSpeed * Time.fixedDeltaTime);

            _rigidbody.MoveRotation(rotation);

        }
    }
}

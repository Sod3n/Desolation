using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class MakeDamage : StateBehaviour
    {
        
        [Inject] private Transform _transform;


        [Header("Remember to asign collider")]
        [SerializeField] protected float _damageScale;

        private void OnTriggerStay(Collider collider)
        {
            if (collider is null) return;

            if (collider.transform == _transform) return;

            Damage(collider);
        }

        protected virtual void Damage(Collider collider)
        {
            Debug.Log("Damage " + collider.name + " with damage scale: " + _damageScale);
        }
    }
}

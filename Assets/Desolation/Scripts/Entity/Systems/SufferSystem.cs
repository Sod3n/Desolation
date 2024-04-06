using System;
using Desolation.Scripts.Entity.Model;
using UnityEngine;
using Zenject;

namespace Desolation.Scripts.Entity.Systems
{
    public class SufferSystem : MonoBehaviour
    {
        public event Action OnDamageReceived;

        [Inject] private Health _health;
        [Inject] private Rigidbody _rigidbody;
        
        public void ReceiveDamage(float amount)
        {
            _health.CurrentHealth -= amount;
            OnDamageReceived?.Invoke();
        }
        
        public void GetPushed(Vector3 direction, float force)
        {
            _rigidbody.AddForce(direction * force, ForceMode.VelocityChange);
        }
    }
}
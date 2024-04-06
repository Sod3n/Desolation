using System;
using UnityEngine;

namespace Desolation.Scripts.Entity.Systems
{
    public class DamageSystem : MonoBehaviour
    {
        public event Action OnHit;
        
        public void PerfomDamage(SufferSystem sufferSystem)
        {
            Debug.Log("Damage " + sufferSystem.gameObject.name + " with damage scale: ");
            sufferSystem.ReceiveDamage(10);
            OnHit?.Invoke();
        }
    }
}
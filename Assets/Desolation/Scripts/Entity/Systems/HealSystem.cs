using Desolation.Scripts.Entity.Model;
using UnityEngine;
using Zenject;

namespace Desolation.Scripts.Entity.Systems
{
    public class HealSystem : MonoBehaviour
    {
        [Inject] private Health _health;
        public void PerformHeal(float amount)
        {
            _health.CurrentHealth += amount;
            Debug.Log("Heal " + amount);
        }
    }
}
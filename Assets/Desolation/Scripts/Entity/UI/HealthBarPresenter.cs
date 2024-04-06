using Desolation.Scripts.Entity.Model;
using Desolation.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Desolation.Scripts.Entity.UI
{
    public class HealthBarPresenter : MonoBehaviour
    {
        [Inject] private Health _health;
        [SerializeField] private Bar _bar;

        private void FixedUpdate()
        {
            _bar.CurrentValue = _health.CurrentHealth;
            _bar.MaxValue = _health.MaxHealth;
        }
    }
}
using Desolation.Scripts.Entity.Model;
using Desolation.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Desolation.Scripts.Entity.UI
{
    public class BarPresenter : MonoBehaviour
    {
        [Inject] private Bar _bar;
        [Inject] private Health _health;

        private void FixedUpdate()
        {
            _bar.CurrentValue = _health.CurrentHealth;
            _bar.MaxValue = _health.MaxHealth;
        }
    }
}
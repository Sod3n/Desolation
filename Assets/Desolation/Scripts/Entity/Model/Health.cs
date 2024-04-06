using System;
using Desolation.Scripts.GameData;
using UnityEngine;
using Zenject;

namespace Desolation.Scripts.Entity.Model
{
    public class Health : MonoBehaviour
    {
        [Inject] private SheetContainer _sheetContainer;
        [Inject] private Key _key;

        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;
        
        public float MaxHealth
        {
            get => _maxHealth;
            private set => _maxHealth = value;
        }

        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        

        private void Start()
        {
            MaxHealth = _sheetContainer.EntityBase[_key.Value].Health;
            CurrentHealth = MaxHealth;
        }
    }
}
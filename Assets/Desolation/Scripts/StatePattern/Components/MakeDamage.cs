using Desolation.StatePattern;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Desolation.Scripts.Entity.Systems;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class MakeDamage : StateBehaviour
    {
        
        [Inject] private Transform _transform;
        [Inject] private DamageSystem _damageSystem;


        [Header("Remember to asign collider")]
        [SerializeField] protected float _damageScale;

        private List<GameObject> _alreadyDamaged = new List<GameObject>();

        public override void OnEnter()
        {
            _alreadyDamaged.Clear();
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider is null) return;
            
            if(_alreadyDamaged.Contains(collider.gameObject)) return;

            if (collider.transform == _transform) return;

            var sufferSystem = collider.gameObject.GetComponent<SufferSystem>();
            
            if(sufferSystem == null) return;
            
            _damageSystem.PerfomDamage(sufferSystem);
            _alreadyDamaged.Add(collider.gameObject);
        } 
    }
}

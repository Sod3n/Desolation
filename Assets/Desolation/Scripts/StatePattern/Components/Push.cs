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
    public class Push : StateBehaviour
    {
        
        [Inject] private Transform _transform;
        
        [SerializeField] protected float _force;

        private List<GameObject> _alreadyPushed = new List<GameObject>();

        public override void OnEnter()
        {
            _alreadyPushed.Clear();
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider is null) return;
            
            if(_alreadyPushed.Contains(collider.gameObject)) return;

            if (collider.transform == _transform) return;

            var sufferSystem = collider.gameObject.GetComponent<SufferSystem>();
            
            if(sufferSystem == null) return;
            
            var direction = (collider.transform.position - transform.position).normalized;
            
            sufferSystem.GetPushed(direction, _force);
            _alreadyPushed.Add(collider.gameObject);
        } 
    }
}

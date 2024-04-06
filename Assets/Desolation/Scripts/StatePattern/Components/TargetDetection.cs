using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


namespace Desolation.StatePattern
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Targets))]
    public class Agro : MonoBehaviour
    {
        public event Action OnTargetAppeared;
        public event Action OnTargetLosted;
        public event Action OnTargetChanged;
        
        
        [SerializeField] private Targets _targets;
        [SerializeField] private float _detectionDelay;
        private Coroutine _detectPlayerCoroutine;
        private SphereCollider _detectionCollider;
        private bool _hasVisibleTarget;
        private GameObject _lastTarget; 

        private bool _isLastVisibleTarget;

        private void Awake()
        {
            _detectionCollider = GetComponent<SphereCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var targetVisibility = new TargetInfo { Target = other.gameObject };
            _targets.Value.Add(targetVisibility);
            
            _detectPlayerCoroutine = StartCoroutine(DetectTarget(targetVisibility));
        }

        private void OnTriggerExit(Collider other)
        {
            var targetVisibility = _targets.Value.Find(t => t.Target == other.gameObject);
            if (targetVisibility != null)
            {
                
                StopCoroutine(_detectPlayerCoroutine);
                _targets.Value.Remove(targetVisibility);
                
                if(!_hasVisibleTarget) return;
                
                if (_targets.Value.Count(t => t.IsVisible) == 0)
                    OnTargetLosted?.Invoke();
                else
                    OnTargetChanged?.Invoke();
                
            }
        }


        IEnumerator DetectTarget(TargetInfo targetInfo)
        {
            while (true)
            {
                yield return new WaitForSeconds(_detectionDelay);

                Vector3 direction = targetInfo.Target.transform.position - transform.position;
                bool isVisible = IsTargetVisible(targetInfo.Target, direction);

                if (isVisible)
                {
                    targetInfo.IsVisible = true;
                    if (!_hasVisibleTarget)
                    {
                        _hasVisibleTarget = true;
                        OnTargetAppeared?.Invoke();
                    }
                }
                else
                {
                    targetInfo.IsVisible = false;

                    if (_targets.Value.Count(t => t.IsVisible) == 0)
                    {
                        OnTargetLosted?.Invoke();
                    }
                }
            }
        }

        private bool IsTargetVisible(GameObject target, Vector3 direction)
        {
            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, _detectionCollider.radius);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject != target) return false;
            }
            return true;
        }
    }
}
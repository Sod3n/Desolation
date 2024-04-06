using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;


namespace Desolation.StatePattern
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Targets))]
    public class TargetDetection : MonoBehaviour
    {
        public event Action OnTargetAppeared;
        public event Action OnTargetLosted;
        public event Action OnTargetChanged;
        
        
        [SerializeField] private Targets _targets;
        [SerializeField] private float _detectionDelay;
        private SphereCollider _detectionCollider;
        private bool _hasVisibleTarget;
        private GameObject _lastTarget; 

        private bool _isLastVisibleTarget;

        private List<TargetInfo> _targetsToDetect = new List<TargetInfo>();

        private void Awake()
        {
            _detectionCollider = GetComponent<SphereCollider>();
            InvokeRepeating("DetectTargets", 0, _detectionDelay);
        }

        private void OnTriggerEnter(Collider other)
        {
            var targetVisibility = new TargetInfo { Target = other.gameObject };
            _targets.Value.Add(targetVisibility);
            
            _targetsToDetect.Add(targetVisibility);
        }

        private void OnTriggerExit(Collider other)
        {
            var targetVisibility = _targets.Value.Find(t => t.Target == other.gameObject);
            if (targetVisibility != null)
            {
                
                _targetsToDetect.Remove(targetVisibility);
                _targets.Value.Remove(targetVisibility);
                
                if(!_hasVisibleTarget) return;

                if (_targets.Value.Count(t => t.IsVisible) == 0)
                {
                    OnTargetLosted?.Invoke();
                    _hasVisibleTarget = false;
                }
                else
                    OnTargetChanged?.Invoke();
                
            }
        }


        private void DetectTargets()
        {
            foreach (var targetInfo in _targetsToDetect)
            {
                
                Vector3 direction = targetInfo.Target.transform.position - transform.position;
                targetInfo.DistanceLength = direction.magnitude;
                
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
            return true;
            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, _detectionCollider.radius);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject != target) return false;
            }
            return true;
        }
    }
}
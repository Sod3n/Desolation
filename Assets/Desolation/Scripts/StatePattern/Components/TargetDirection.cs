using System.Linq;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class TargetDirection : Direction
    {
        [Inject] private Transform _transform;
        [SerializeField] private Targets _targets;

        public override Vector3 Value 
        {
            get
            {
                var target = _targets.Value.First(t => t.IsVisible).Target;
                var directionToTarget = target.transform.position - _transform.position;
                return directionToTarget;
            }
        }
    }
}
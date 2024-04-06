using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Desolation.StatePattern
{
    public class Targets : MonoBehaviour
    {
        public List<TargetInfo> Value { get; set; } = new List<TargetInfo>();
        public List<TargetInfo> Visible
        {
            get => Value.Where(t => t.IsVisible).ToList(); 
        }
    }
}
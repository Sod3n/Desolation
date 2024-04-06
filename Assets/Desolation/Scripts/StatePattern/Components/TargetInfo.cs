using System;
using UnityEngine;

namespace Desolation.StatePattern
{
    [Serializable]
    public class TargetVisibility
    {
        public GameObject Target { get; set; }
        public bool IsVisible { get; set; }
    }
}
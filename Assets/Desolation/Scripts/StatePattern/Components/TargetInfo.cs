using System;
using UnityEngine;

namespace Desolation.StatePattern
{
    [Serializable]
    public class TargetInfo
    {
        public GameObject Target { get; set; }
        public bool IsVisible { get; set; }
        public float DistanceLength { get; set; }
    }
}
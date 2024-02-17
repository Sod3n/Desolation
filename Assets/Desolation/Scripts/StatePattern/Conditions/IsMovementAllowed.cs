using Cysharp.Threading.Tasks;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class IsMovementAllowed : TransitionCondition
    {
        public override bool IsSatisfied
        {
            get
            {
                return Allowed;
            }
        }
        public bool Allowed { get; set; } = false;
    }
}

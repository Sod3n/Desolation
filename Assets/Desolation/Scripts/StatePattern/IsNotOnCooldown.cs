using Cysharp.Threading.Tasks;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class IsNotOnCooldown : TransitionCondition
    {
        [SerializeField] private Cooldown _cooldown;
        public override bool IsSatisfied
        {
            get
            {
                Debug.Log("In cooldown " + _cooldown.RemainingTime);
                return _cooldown.Task.Status.IsCompleted();
            }
        }

    }
}

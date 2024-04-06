using Cysharp.Threading.Tasks;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class EventOccurred : TransitionCondition
    {
        private bool _isSatisfied;
        public override bool IsSatisfied
        {
            get;
        }
    }
}

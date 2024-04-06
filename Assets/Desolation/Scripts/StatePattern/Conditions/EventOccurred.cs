using Cysharp.Threading.Tasks;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using Canopy.Events;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    [RequireComponent(typeof(EventOccurredSetter))]
    public class EventOccurred : TransitionCondition
    {
        [SerializeField] private EventRef _eventRef;
        
        public bool Value
        {
            get => IsSatisfied;
            set => _isSatisfied = value;
        }

        public EventRef EventRef
        {
            get => _eventRef;
            set => _eventRef = value;
        }
    }
}

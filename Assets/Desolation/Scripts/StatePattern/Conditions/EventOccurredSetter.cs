using Cysharp.Threading.Tasks;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class EventOccurredSetter : StateBehaviour
    {
        private EventOccurred _eventOccurred;
        private void Awake()
        {
            _eventOccurred = GetComponent<EventOccurred>();
            _eventOccurred.EventRef.Initialize();
        }

        public override void OnEnter()
        {
            _eventOccurred.Value = false;
            
            _eventOccurred.EventRef += ToTrue;
        }

        private void ToTrue()
        {
            _eventOccurred.Value = true;
        }

        public override void OnExit()
        {
            _eventOccurred.EventRef -= ToTrue;
        }
    }
}

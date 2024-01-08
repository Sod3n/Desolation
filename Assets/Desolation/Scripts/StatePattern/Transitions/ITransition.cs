using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.StatePattern
{
    public interface ITransition
    {
        public IState TargetState { get; set; }

        public void Invoke();
        
        public event Invoked OnInvoked;

        public delegate void Invoked(IState fromState);
    }
}

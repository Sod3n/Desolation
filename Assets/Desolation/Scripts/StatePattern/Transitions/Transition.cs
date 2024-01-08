using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Transition : ITransition
    {
        protected IStateController _stateController;
        public IState TargetState { get; set; }

        public event ITransition.Invoked OnInvoked = _ => { };

        public Transition(IState targetState, IStateController stateController)
        {
            TargetState = targetState;
            _stateController = stateController;
        }

        public virtual void Invoke()
        {
            var fromState = _stateController.CurrentState;

            _stateController.CurrentState = TargetState;
            if(_stateController.CurrentState == TargetState)
                OnInvoked.Invoke(fromState);
        }
    }
}

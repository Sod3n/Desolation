using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.StatePattern
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public StateTickables Tickables { get; }
        public List<ITransition> Transitions { get; set; }
        public ITransition AddTransition(IState state, IStateController stateController);
    }
}

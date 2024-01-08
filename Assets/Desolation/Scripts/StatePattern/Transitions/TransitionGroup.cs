using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public abstract class TransitionGroup : ITransitionGroup
    {
        [Inject] private List<ITransition> _transitions = new List<ITransition>();

        public void AddTransitionsToState(IState state)
        {
            state.Transitions.AddRange(_transitions);
        }

        public void ExceptTransitionsFromState(IState state)
        {
            state.Transitions = state.Transitions.Except(_transitions).ToList();
        }
    }
}

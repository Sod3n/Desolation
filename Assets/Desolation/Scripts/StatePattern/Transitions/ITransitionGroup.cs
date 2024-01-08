using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.StatePattern
{
    public interface ITransitionGroup
    {
        public void ExceptTransitionsFromState(IState state);
        public void AddTransitionsToState(IState state);
    }
}

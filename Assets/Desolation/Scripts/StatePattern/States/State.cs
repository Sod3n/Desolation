using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class State : Kernel, IState
    {
        [Inject] public StateTickables Tickables { get; private set; }
        [Inject] public List<ITransition> Transitions { get; set; } = new List<ITransition>();

        [InjectOptional] public int Priority { get; private set; } = 0;

        [Inject] protected List<IStateComponent> _components = new List<IStateComponent>();
        [Inject] protected List<IStateComponent.IEnterable> _enterables = new List<IStateComponent.IEnterable>();
        [Inject] protected List<IStateComponent.IExitable> _exitables = new List<IStateComponent.IExitable>();

        public IState NextState { get; set; } = null;

        public List<IStateComponent> Components { get => _components; }
        public Action<IState> OnStateChange { get; set; }

        public void Enter()
        {
            foreach (var enterable in _enterables)
            {
                enterable.OnEnter();
            }
        }

        public void Exit()
        {
            foreach (var exitable in _exitables)
            {
                exitable.OnExit();
            }
        }

        public ITransition AddTransition(IState state, IStateController stateController)
        {
            var transition = Transitions.FirstOrDefault(t => t?.TargetState == state);

            if (transition == null)
            {
                transition = new Transition(state, stateController);
                Transitions.Add(transition);
                return transition;
            }

            return transition;
        }
    }
}

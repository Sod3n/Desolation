using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class StateController : IStateController, IInitializable
    {
        [Inject] public ITransition BaseTransition { get; set; }

        private IState _state;
        public IState CurrentState
        {
            get 
            {
                return _state;
            }
            set
            {
                if(_state == value) return;

                if (!_state.Transitions.Any(t => t.TargetState == value)) return;

                _state.Transitions.ForEach(t => Debug.Log(t.TargetState.GetHashCode()));

                _state?.Exit();
                _state = value;
                _state?.Enter();
            }
        }

        public void Initialize()
        {
            _state = BaseTransition.TargetState;
            _state.Enter();
        }
    }
}

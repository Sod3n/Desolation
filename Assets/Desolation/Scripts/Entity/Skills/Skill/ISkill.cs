using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Experimental.Rendering.RayTracingAccelerationStructure;

namespace Entity.Skills
{
    /// <summary>
    /// Just represent list of ISkillComponents as one ISkillComponent.
    /// All methods executes for all components in list, exclude Tick(). It executes only for current state of skill.
    /// State changes when IsDone of all components with current StateOfExecution become true. Or there no components.
    /// If one of components failed to use than skill considered to be failed to use.
    /// </summary>
    public interface ISkill : 
        Zenject.IInitializable, Zenject.ITickable, 
        Zenject.IFixedTickable, Zenject.ILateTickable,
        ISkillComponent.IUseable, ISkillComponent.IBreakable
    {

        public State CurrentState { get; }

        public List<ISkillComponent> Components { get; }


        public enum State : int 
        { 
            None = -1 
        }

        public static State ToState(uint i) 
        { 
            return (State)i; 
        }
        public class StateIterator
        {
            private int _count;
            private State _state = 0;

            public State State { get => _state; set => _state = value; }

            public StateIterator(int count)
            {
                _count = count;
            }

            public void NextState()
            {
                _state++;

                if((int)_state >= _count)
                    _state = 0;
            }
            public void Reset()
            {
                _state = 0;
            }
            public bool IsNone()
            {
                return _state == State.None;
            }
        }
    }
}

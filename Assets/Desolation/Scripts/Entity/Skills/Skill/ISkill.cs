using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Skills
{
    /// <summary>
    /// Just represent list of ISkillComponents as one ISkillComponent.
    /// All methods executes for all components in list, exclude Tick(). It executes only for current state of skill.
    /// State changes when IsDone of all components with current StateOfExecution become true. Or there no components.
    /// If one of components failed to use than skill considered to be failed to use.
    /// </summary>
    public interface ISkill
    {
        public void Use();
        public void Tick();
        public void FixedTick();
        public void Break();
        public State CurrentState { get; }
        public bool IsDone { get; }

        public List<ISkillComponent> Components { get; }

        public class State
        {
            public static readonly State Prepare = new State();
            public static readonly State Action = new State();
            public static readonly State Recovery = new State();

            private static List<State> _states = new List<State>
            {
                Prepare,
                Action,
                Recovery
            };

            public static State First
            {
                get
                {
                    return _states.FirstOrDefault();
                }
            }

            public State NextState
            {
                get
                {
                    return _states.SkipWhile(s => s != this).Skip(1).FirstOrDefault();
                }
            }
        }
    }
}

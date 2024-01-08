using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.Entity.Antaine
{
    public class WingsOfNight : Transition
    {
        public WingsOfNight(IState targetState, IStateController stateController) : base(targetState, stateController)
        {
        }
    }
}

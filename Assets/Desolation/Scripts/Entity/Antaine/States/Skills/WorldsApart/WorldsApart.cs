using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.Entity.Antaine
{
    public class WorldsApart : Transition
    {
        public WorldsApart(IState targetState, IStateController stateController) : base(targetState, stateController)
        {
        }

        public class ChargeActions : Charge.Actions { }
    }
}

using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class BasicAttack : Transition
    {
        public BasicAttack(IState targetState, IStateController stateController) : base(targetState, stateController)
        {
        }
    }
}

using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class DemonicSweep : Transition
    {
        public DemonicSweep(IState targetState, IStateController stateController) : base(targetState, stateController)
        {
        }
    }
}

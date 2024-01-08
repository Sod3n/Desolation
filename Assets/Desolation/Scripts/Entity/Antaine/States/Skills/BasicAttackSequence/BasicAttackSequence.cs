using Cysharp.Threading.Tasks;
using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Desolation.Entity.Antaine
{
    public class BasicAttackSequence : TransitionSequence
    {
        public BasicAttackSequence(List<ITransition> skills, IStateController stateController) : base(skills, stateController)
        {
        }
    }
}

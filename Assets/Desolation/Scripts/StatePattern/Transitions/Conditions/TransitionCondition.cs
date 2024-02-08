using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public abstract class TransitionCondition : MonoBehaviour
    {
        public abstract bool IsSatisfied { get; }
    }
}

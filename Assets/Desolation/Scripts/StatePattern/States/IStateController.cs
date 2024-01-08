using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.StatePattern
{
    public interface IStateController
    {
        public IState CurrentState { get; set; }
        public ITransition BaseTransition { get; }
    }
}

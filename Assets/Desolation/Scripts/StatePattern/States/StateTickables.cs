using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class StateTickables
    {
        [Inject] public List<IStateComponent.ITickable> BaseTickables;
        [Inject] public List<IStateComponent.IFixedTickable> FixedTickables;
        [Inject] public List<IStateComponent.ILateTickable> LateTickables;
    }
}

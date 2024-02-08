using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Transition : AbstractTransition
    {
        [SerializeField] private TransitionData _transitionData;
        public override List<TransitionData> AddTransitionDataToList(List<TransitionData> list)
        {
            list.Add(_transitionData);
            return list;
        }

        public override int GetMaxTransitionCount()
        {
            return 1;
        }

        [Inject]
        private void Initialize()
        {
            _transitionData.EventReference.Initialize();
        }
    }
}
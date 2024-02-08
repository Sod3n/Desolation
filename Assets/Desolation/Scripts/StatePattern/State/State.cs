using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.StatePattern
{
    public class State : AbstractState
    {

        public override void Enter()
        {
            gameObject.SetActive(true);
        }
        public override void Exit()
        {
            gameObject.SetActive(false);
        }
    }
}

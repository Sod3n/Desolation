using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Desolation.StatePattern
{
    [Serializable]
    public class TransitionList
    {
        public List<TransitionData> Value = new List<TransitionData>();
    }
}

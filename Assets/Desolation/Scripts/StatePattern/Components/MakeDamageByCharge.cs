using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class MakeDamageByCharge : MakeDamage
    {
        [SerializeField] private Charge _charge;
        
    }
}

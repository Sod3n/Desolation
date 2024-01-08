using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class MakeDamageByCharge : MakeDamage
    {
        private Charge.Power _charge;
        public MakeDamageByCharge(Transform transform, Settings settings, Charge.Power charge)
            : base( transform, settings)
        {
            _charge = charge;
        }

        public override void FixedTick()
        {
            DamageAllInDamageZone(_settings.DamageScale + _charge.Value);
        }
    }
}

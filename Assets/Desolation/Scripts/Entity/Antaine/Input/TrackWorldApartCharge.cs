using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class TrackWorldApartCharge : IInitializable
    {
        [Inject] private WorldsApart.ChargeActions _charge;
        [Inject] private Input _input;

        public void Initialize()
        {
            // reminder: this construction somehow invoke only subscribers that was bind 
            // before bind action to the event.
            // _input.SkillThreeReleased += _charge.OnChargeInterapted;

            // but this one track subscribers that was bind after bind action to the event.
            _input.SkillThreeReleased += () => { _charge.OnChargeInterapted(); };
        }
    }
}

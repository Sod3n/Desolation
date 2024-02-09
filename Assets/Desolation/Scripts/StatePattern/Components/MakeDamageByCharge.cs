using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class MakeDamageByCharge : MakeDamage
    {
        [SerializeField] private Charge _charge;

        protected override void Damage(Collider collider)
        {
            Debug.Log("Damage " + collider.name + " with damage scale: " + (_damageScale * _charge.Power));
        }
    }
}

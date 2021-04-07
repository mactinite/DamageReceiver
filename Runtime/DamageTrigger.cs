using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.DamageReceiver
{
    public class DamageTrigger : MonoBehaviour
    {
        public float damage = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // if other collider has a DamageReceiver, apply that damage
            if(collision.TryGetComponent<IDamageReceiver>(out var DamageReceiver))
            {
                Damage dmg = new Damage();
                dmg.damageAmount = damage;
                DamageReceiver.DamageAt(dmg, collision.ClosestPoint(transform.position));
            }
        }

    }
}

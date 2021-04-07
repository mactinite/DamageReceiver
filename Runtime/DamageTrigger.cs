using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.ExtensibleDamageSystem
{
    public class DamageTrigger : MonoBehaviour
    {
        public float damage = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // if other collider has a damageable, apply that damage
            if(collision.TryGetComponent<IDamageable>(out var damageable))
            {
                Damage dmg = new Damage();
                dmg.damageAmount = damage;
                damageable.DamageAt(dmg, collision.ClosestPoint(transform.position));
            }
        }

    }
}

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
                damageable.DamageAt(damage, collision.ClosestPoint(transform.position));
            }
        }

    }
}

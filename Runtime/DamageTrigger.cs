using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.DamageReceiver;
namespace mactinite.DamageReceiver
{
    public class DamageTrigger : MonoBehaviour
    {
        public float damage = 10;
        public DamageType damageType;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // if other collider has a DamageReceiver, apply that damage
            if(collision.TryGetComponent<IDamageReceiver>(out var DamageReceiver))
            {
                DamageReceiver.Damage(damage, collision.ClosestPoint(transform.position));
            }
        }

    }
}

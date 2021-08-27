using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.DamageReceiver;
using mactinite.ToolboxCommons;
namespace mactinite.DamageReceiver
{
    public class DamageTrigger : MonoBehaviour
    {
        public float damage = 10;
        public LayerMask damageMask;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.IsInLayerMask(damageMask))
            {
                // if other collider has a DamageReceiver, apply that damage
                if (collision.TryGetComponent<IDamageReceiver>(out var DamageReceiver))
                {
                    DamageReceiver.DamageAt(new BasicDamage(damage), collision.ClosestPoint(transform.position));
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.IsInLayerMask(damageMask))
            {

                // if other collider has a DamageReceiver, apply that damage
                if (collision.TryGetComponent<IDamageReceiver>(out var DamageReceiver))
                {
                    DamageReceiver.DamageAt(new BasicDamage(damage), collision.ClosestPoint(transform.position));
                }
            }
        }

    }
}

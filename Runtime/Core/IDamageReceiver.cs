using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.DamageReceiver
{
    /// <summary>
    /// Defines an interface to classes that can have damage applied to them.
    /// </summary>
    public interface IDamageReceiver
    {

        /// <summary>
        /// Apply straight damage to DamageReceiver.
        /// </summary>
        /// <param name="damage">damage to apply</param>
        public void Damage(Damage damage);
        /// <summary>
        /// Apply straight damage to DamageReceiver.
        /// </summary>
        /// <param name="damage">damage to apply</param>
        public void Damage(float damage);

        /// <summary>
        /// Apply straight damage to DamageReceiver.
        /// </summary>
        /// <param name="damage">damage to apply</param>
        public void Damage(float damage, Vector2 position);

        /// <summary>
        /// Apply straight damage to DamageReceiver, at a position
        /// </summary>
        /// <param name="damage">damage to apply</param>
        public void DamageAt(Damage damage, Vector2 at);
        /// <summary>
        /// Restore health to the damage receiver
        /// </summary>
        /// <param name="amount">amount to heal</param>
        public void Heal(float amount);

        public Transform transform {get;}
    }
}

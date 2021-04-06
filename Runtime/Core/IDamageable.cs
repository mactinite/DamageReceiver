using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.ExtensibleDamageSystem
{
    /// <summary>
    /// Defines an interface to classes that can have damage applied to them.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// Apply straight damage to damageable.
        /// </summary>
        /// <param name="damage">damage to apply</param>
        public void Damage(float damage);

        /// <summary>
        /// Apply straight damage to damageable, at a position
        /// </summary>
        /// <param name="damage">damage to apply</param>
        public void DamageAt(float damage, Vector2 at);

        public Transform transform {get;}
    }
}

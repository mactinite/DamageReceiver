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
        public void Damage(IDamage damage);
                /// <summary>
        /// Apply straight damage to DamageReceiver. at position;
        /// </summary>
        /// <param name="damage">damage to apply</param>
        public void DamageAt(IDamage damage, Vector2 at);
        public Transform transform {get;}
    }
}

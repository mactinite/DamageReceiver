using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


namespace mactinite.ExtensibleDamageSystem.statusEffects
{

    [System.Serializable]
    public abstract class StatusEffect : ScriptableObject
    {

        public float duration = 1f;
        public bool stacks;


        public float currentLifetime { get; set; } = 0f;
        public bool hasPopped { get; set; } = false;



        /// <summary>
        /// Called to update the status effect.
        /// this should be called every frame (Update) while the status effect is on the stack
        /// </summary>
        /// <param name="d">Damageable in context</param>
        public virtual void OnTick(IDamageable d)
        {

            if (!hasPopped)
                currentLifetime += Time.deltaTime;

            if (currentLifetime > duration)
            {
                hasPopped = true;
                OnPop(d);
            }
        }

        /// <summary>
        /// Called when the status effect pops and is removed from the stack.
        /// Can be used to add effects at the end of a status effect
        /// </summary>
        /// <param name="d">Damageable in context</param>
        public virtual void OnPop(IDamageable d)
        {

        }

        /// <summary>
        /// Resets the status effect to it's initial state
        /// Can be used to extend non-stacking status effects.
        /// </summary>
        /// <param name="d">Damageable in context</param>
        public virtual void Reset(IDamageable d)
        {
            currentLifetime = 0;
            hasPopped = false;
        }

        public virtual StatusEffect Clone()
        {
            return (StatusEffect)this.MemberwiseClone();
        }
    }
}

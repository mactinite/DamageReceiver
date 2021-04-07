using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.ExtensibleDamageSystem.statusEffects
{
    [System.Serializable, CreateAssetMenu(fileName = "New DoTStatusEffect", menuName = "Damage2D/Status Effects/New DoT Status Effect")]
    public class DoTStatusEffect : StatusEffect
    {
        public int damagePerTick = 1;
        public float ticksPerSecond = 2f;
        private ParticleSystem instantiatedVisualEffect = null;
        public ParticleSystem visualEffect;
        public Color damageColor = Color.red;
        
        public override void OnTick(IDamageable d)
        {
            if (instantiatedVisualEffect == null)
            {
                instantiatedVisualEffect = Instantiate(visualEffect, d.transform.position, d.transform.rotation, d.transform);
            }

            base.OnTick(d);

            if (!hasPopped)
            {
                var mod = currentLifetime % (1 / ticksPerSecond);
                if (mod < 0.01f)
                {
                    d.Damage(damagePerTick);
                }
            }
        }
        public override void OnPop(IDamageable d)
        {
            if (instantiatedVisualEffect != null)
            {
                instantiatedVisualEffect.Stop();
                instantiatedVisualEffect = null;
            }
        }

        public override void Reset(IDamageable d)
        {
            currentLifetime = currentLifetime % (1 / ticksPerSecond);
            hasPopped = false;
        }
    }
}

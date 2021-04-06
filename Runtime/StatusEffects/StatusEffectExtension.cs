using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.ExtensibleDamageSystem.statusEffects
{
    public class StatusEffectExtension : MonoBehaviour, IEffectable
    {
        
        public List<StatusEffect> statusEffects = new List<StatusEffect>();
        private IDamageable damageable;

        private void Start()
        {
            if (!TryGetComponent<IDamageable>(out damageable))
            {
                Debug.LogWarning("No Damageable Attached! StatusEffectExtension requires a damageable. Aborting.");
                this.enabled = false;
            }
        }

        private void Update()
        {
            for (int i = statusEffects.Count - 1; i >= 0; i--)
            {
                statusEffects[i].OnTick(damageable);
                if (statusEffects[i].hasPopped)
                {
                    statusEffects.RemoveAt(i);
                }
            }
        }

        public void ApplyStatusEffect(StatusEffect effect)
        {
            var existingEffectIndex = GetStatusIndex(effect);
            if (effect.stacks || existingEffectIndex == -1)
            {
                statusEffects.Add(effect);
            }
            else
            {
                statusEffects[existingEffectIndex].Reset(damageable);
            }
        }

        int GetStatusIndex(StatusEffect effect)
        {
            if (statusEffects.Contains(effect))
            {
                return statusEffects.IndexOf(effect);
            }
            else
            {
                return -1;
            }
        }
    }
}


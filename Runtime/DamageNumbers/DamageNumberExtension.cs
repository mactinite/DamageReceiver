using mactinite.ExtensibleDamageSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.ExtensibleDamageSystem.Numbers
{

    public class DamageNumberExtension : MonoBehaviour
    {
        private Damageable damageable;

        private void Start()
        {
            if (!TryGetComponent<Damageable>(out damageable))
            {
                Debug.LogWarning("No Damageable Attached! DamageNumberExtensions requires a damageable. Aborting.");
                this.enabled = false;
            }
            damageable.OnDamage += OnDamage;
        }

        public void OnDamage(Vector2 position, Damage dmg)
        {
            DamageDisplayManager.SpawnText(dmg.damageAmount.ToString("0"), Color.white, position);
        }

        public void OnDamage(Vector2 position, Damage dmg, Color color)
        {
            DamageDisplayManager.SpawnText(dmg.damageAmount.ToString("0"), color, position);
        }
    }
}

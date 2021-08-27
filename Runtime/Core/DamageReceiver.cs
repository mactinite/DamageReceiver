using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace mactinite.DamageReceiver
{
    /// <summary>
    /// DamageReceiver that simply tracks health and fires events.
    /// Forms the base for the DamageReceiver system.
    /// Implements the IDamageReceiver interface. 
    /// </summary>
    public class DamageReceiver : MonoBehaviour, IDamageReceiver
    {
        public float health = 100;
        public float maxHealth = 100;
        public bool destroyed = false;
        public Action<Vector2, IDamage> OnDamage;
        public Action<float> OnHeal;
        public Action<Vector2> OnDestroyed;
        public Func<IDamage, IDamage> OnProcessDamage;
        [HideInInspector]
        public bool wasDamagedThisFrame = false;

        public GameObject lastDamagedBy;

        private float iTimer = 0;
        public float iTime = 0.08f;

        Transform IDamageReceiver.transform { get => transform;}

        public virtual void Update()
        {
            if (iTimer >= 0)
            {
                iTimer -= Time.deltaTime;
            }
            
        }

        private void LateUpdate() {
            if(wasDamagedThisFrame) {
                iTimer = iTime;
                wasDamagedThisFrame = false;
            }
        }

        public void Damage(IDamage damage)
        {
            DamageAt(damage, transform.position);
        }

        public void DamageAt(IDamage damage, Vector2 at)
        {
            if (iTimer > 0) return;
            // let extensions pre-process damage. Iterate through registered processors and execute the method
            IDamage dmg = damage;
            if (OnProcessDamage != null)
            {
                foreach (Func<IDamage, IDamage> subscriber in OnProcessDamage.GetInvocationList())
                {
                    dmg = subscriber(dmg);
                }
            }

            // apply damage and invoke events
            if (health - dmg.damageAmount <= 0 && !destroyed)
            {
                health = 0;
                dmg.newHealth = health;
                // emit destroyed event and let extensions handle reactions like recycling or destroying.
                OnDamage?.Invoke(at, dmg);
                OnDestroyed?.Invoke(at);
                destroyed = true;
            }
            else
            {
                health -= dmg.damageAmount;
                dmg.newHealth = health;
                // same as destroyed event, but for damage. Extensions can handle things like spawning effects.
                OnDamage?.Invoke(at, dmg);
            }
            var damageReceiver = dmg.source?.GetComponentInParent<DamageReceiver>();
            lastDamagedBy = damageReceiver ? damageReceiver.gameObject : dmg.source;
            wasDamagedThisFrame = true;
        }

        public void Heal(float amount) {
            if(health + amount <= maxHealth){
                health = health + amount;
                OnHeal?.Invoke(amount);
            } else {
                var healAmt = maxHealth - health;
                health = maxHealth;
                OnHeal?.Invoke(healAmt);
            }
        }
    }
}

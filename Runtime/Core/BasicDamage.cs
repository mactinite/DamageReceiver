using UnityEngine;

namespace mactinite.DamageReceiver
{
    public class BasicDamage : IDamage
    {
        public float damageAmount { get; set; }
        public GameObject source { get; set; }
        public float newHealth { get; set; }

        public BasicDamage(float amount)
        {
            damageAmount = amount;
        }

        public BasicDamage(float amount, GameObject sourceObject)
        {
            damageAmount = amount;
            source = sourceObject;
        }
    }
}
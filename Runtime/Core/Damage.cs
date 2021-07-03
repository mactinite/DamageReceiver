using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;

namespace mactinite.DamageReceiver
{
    [System.Serializable]
    public class Damage
    {
        public float newHealth;
        public float damageAmount;
        public GenericDictionary parameters = new GenericDictionary();
        public GameObject source;
        public Damage(float damageAmount, float newHealth)
        {
            this.damageAmount = damageAmount;
        }

        public Damage(float damageAmount, GameObject source)
        {
            this.damageAmount = damageAmount;
            this.source = source;
        }

        public Damage(float damageAmount)
        {
            this.damageAmount = damageAmount;
        }
        public Damage()
        {
            this.damageAmount = 1;
        }
    }

}


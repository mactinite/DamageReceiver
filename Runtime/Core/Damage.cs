using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;

namespace mactinite.DamageReceiver
{
    [System.Serializable]
    public class Damage
    {
        public float damageAmount;
        public DamageType damageType;
        public GenericDictionary parameters = new GenericDictionary();

        public Damage(float damageAmount, DamageType type)
        {
            this.damageAmount = damageAmount;
            this.damageType = type;
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


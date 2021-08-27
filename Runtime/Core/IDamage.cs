using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;

namespace mactinite.DamageReceiver
{
    public interface IDamage
    {
        public float damageAmount { get; set; }
        public float newHealth { get; set; }
        public GameObject source { get; set; }
    }

}


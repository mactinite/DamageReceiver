using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;
using mactinite.EDS;

namespace mactinite.EDS.Basic
{
    /// <summary>
    /// A sample damage implementation.
    /// </summary>
    public class BasicDamage : DamageBase
    {
        public BasicDamage()
        {
        }

        public BasicDamage(float amount) : base(amount)
        {
        }
    }

}
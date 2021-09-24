using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;

namespace mactinite.EDS.Basic
{
    public class DamageEvent : MonoBehaviour
    {
        public FloatUnityEvent OnDamage = new FloatUnityEvent();


        private void Start()
        {
            GetComponent<BasicDamageReceiver>().OnDamage += OnDamageReceived;
        }

        private void OnDamageReceived(Vector2 pos, BasicDamage dmg)
        {
            OnDamage.Invoke(dmg.Amount);
        }

    }
}

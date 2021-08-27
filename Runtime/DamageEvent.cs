using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.DamageReceiver;
using mactinite.ToolboxCommons;
namespace mactinite.DamageReceiver
{
    public class DamageEvent : MonoBehaviour
    {
        public FloatUnityEvent OnDamage = new FloatUnityEvent();


        private void Start()
        {
            GetComponent<DamageReceiver>().OnDamage += OnDamageReceived;
        }

        private void OnDamageReceived(Vector2 pos, IDamage dmg)
        {
            OnDamage.Invoke(dmg.damageAmount);
        }

    }
}

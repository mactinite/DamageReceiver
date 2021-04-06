using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.ExtensibleDamageSystem.examples
{
    public class DestroyOnDeath : MonoBehaviour
    {
        private Damageable damageable;
        public void Start()
        {
            if(!TryGetComponent<Damageable>(out damageable))
            {
                Debug.LogWarning("No Damageable Attached! DestroyOnDeath requires a damageable.");
            }

            damageable.OnDestroyed += Trigger;
        }
        public void Trigger(Vector2 position)
        {
            damageable.OnDestroyed -= Trigger;
            Destroy(this.gameObject);
        }
    }
}



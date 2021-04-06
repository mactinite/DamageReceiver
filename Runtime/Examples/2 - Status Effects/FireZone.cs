using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ExtensibleDamageSystem.statusEffects;
public class FireZone : MonoBehaviour
{
    public StatusEffect effect;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IEffectable>(out var effectable))
        {
            var fireEffect = effect.Clone();
            effectable.ApplyStatusEffect(fireEffect);
        }
    }
}

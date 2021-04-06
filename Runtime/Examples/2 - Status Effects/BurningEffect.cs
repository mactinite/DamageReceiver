using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningEffect : MonoBehaviour
{
    private SpriteRenderer parentSprite;
    private ParticleSystem particleSystem;
    private void Start()
    {
        parentSprite = GetComponentInParent<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
        if(parentSprite && particleSystem)
        {
            var shape = particleSystem.shape;
            shape.shapeType = ParticleSystemShapeType.SpriteRenderer;
            shape.spriteRenderer = parentSprite;
        } else
        {
            Debug.LogWarning("Missing required components for a fire effect...");
        }
    }


}

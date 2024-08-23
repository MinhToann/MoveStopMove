using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammers : BulletBase
{
    [SerializeField] private ParticleSystem hammerTrail;
    [SerializeField] ParticleSystem effectBoom;
    public override void ThrowForward()
    {
        base.ThrowForward();
        EffectTrail();
    }
    private void EffectTrail()
    {
        hammerTrail.Play();
    }
    public override void SpawnEffect()
    {
        base.SpawnEffect();
        ParticleSystem particalBoom = Instantiate(effectBoom);
        particalBoom.Play();
        particalBoom.transform.position = TF.position;
    }
}

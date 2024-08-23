using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wands : BulletBase
{
    [SerializeField] private ParticleSystem wandTrail;
    [SerializeField] ParticleSystem effectBoom;
    public override void ThrowForward()
    {
        base.ThrowForward();
        EffectTrail();
    }
    private void EffectTrail()
    {
        wandTrail.Play();
    }
    public override void SpawnEffect()
    {
        base.SpawnEffect();
        ParticleSystem particalBoom = Instantiate(effectBoom);
        particalBoom.Play();
        particalBoom.transform.position = TF.position;
    }
}

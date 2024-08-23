using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : BulletBase
{
    [SerializeField] ParticleSystem swordFireTrail;
    [SerializeField] ParticleSystem effectBoom;
    public override void ThrowForward()
    {
        base.ThrowForward();
        EffectTrail();
    }
    private void EffectTrail()
    {
        swordFireTrail.Play();
    }
    public override void SpawnEffect()
    {
        base.SpawnEffect();
        ParticleSystem particalBoom = Instantiate(effectBoom);
        particalBoom.Play();
        particalBoom.transform.position = TF.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wands : BulletBase
{
    [SerializeField] private ParticleSystem wandTrail;
    public override void ThrowForward()
    {
        base.ThrowForward();
        EffectTrail();
    }
    private void EffectTrail()
    {
        wandTrail.Play();
    }
}

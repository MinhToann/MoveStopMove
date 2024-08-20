using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : BulletBase
{
    [SerializeField] ParticleSystem swordFireTrail;
    public override void ThrowForward()
    {
        base.ThrowForward();
        EffectTrail();
    }
    private void EffectTrail()
    {
        swordFireTrail.Play();
    }    
}

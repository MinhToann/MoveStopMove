using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staffs : BulletBase
{
    [SerializeField] private ParticleSystem staffTrail;
    [SerializeField] private ParticleSystem staffBoom;
    public override void ThrowForward()
    {
        base.ThrowForward();
        EffectTrail();
    }
    private void EffectTrail()
    {
        staffTrail.Play();
    }
}

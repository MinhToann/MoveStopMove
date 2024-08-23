using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daggers : BulletBase
{
    [SerializeField] ParticleSystem effectBoom;
    public override void ThrowForward()
    {
        base.ThrowForward();
    }

    public override void SpawnEffect()
    {
        base.SpawnEffect();
        ParticleSystem particalBoom = Instantiate(effectBoom);
        particalBoom.Play();
        particalBoom.transform.position = TF.position;
    }
}

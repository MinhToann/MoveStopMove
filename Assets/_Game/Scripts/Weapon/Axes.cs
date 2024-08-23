using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axes : BulletBase
{
    [SerializeField] ParticleSystem effectBoom;
    private float rotateSpeed = 5f;
    public override void ThrowForward()
    {
        base.ThrowForward();
        TF.Rotate(new Vector3(0, 0, 90) * rotateSpeed * Time.deltaTime);
    }
    public override void SpawnEffect()
    {
        base.SpawnEffect();
        ParticleSystem particalBoom = Instantiate(effectBoom);
        particalBoom.Play();
        particalBoom.transform.position = TF.position;
    }
}

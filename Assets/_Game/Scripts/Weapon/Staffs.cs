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
    //public override void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);
    //    SpawnEffect();
    //}
    //private void SpawnEffect()
    //{
    //    ParticleSystem bulletBoom = Instantiate(staffTrail);
    //    bulletBoom.transform.position = TF.position;
    //    bulletBoom.Play();
    //    Invoke(nameof(OnDespawn), 0.5f);
    //}    
    //private void OnDespawn(ParticleSystem trail)
    //{
    //    Destroy(trail.gameObject);
    //}    
}

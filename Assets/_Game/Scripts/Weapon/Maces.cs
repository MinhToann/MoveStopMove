using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Maces : BulletBase
{
    [SerializeField] VisualEffect effect;
    public override void ThrowForward()
    {
        base.ThrowForward();
        Instantiate(effect);
        effect.Play();
    }
    public void SpawnEffect()
    {
        
    }    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axes : BulletBase
{
    private float rotateSpeed = 5f;
    public override void ThrowForward()
    {
        base.ThrowForward();
        TF.Rotate(new Vector3(0, 0, 90) * rotateSpeed * Time.deltaTime);
    }
}

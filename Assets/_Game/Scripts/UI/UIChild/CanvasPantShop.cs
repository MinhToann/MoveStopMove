using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPantShop : UICanvas
{
    [SerializeField] Transform parentTemplate;

    public Transform SetParent()
    {
        return parentTemplate;
    }
}

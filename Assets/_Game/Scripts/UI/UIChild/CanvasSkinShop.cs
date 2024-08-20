using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSkinShop : UICanvas
{
    [SerializeField] Transform parentTemplate;

    public Transform SetParent()
    {
        return parentTemplate;
    }
}

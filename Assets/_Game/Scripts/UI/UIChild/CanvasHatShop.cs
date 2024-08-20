using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasHatShop : UICanvas
{
    [SerializeField] Transform parentTemplate;

    public Transform SetParent()
    {
        return parentTemplate;
    }    
}

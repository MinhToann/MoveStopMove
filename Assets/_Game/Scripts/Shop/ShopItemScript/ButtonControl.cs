using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ButtonControl : MonoBehaviour
{

    [SerializeField] private CanvasShop canvasShop;
    [SerializeField] TextMeshProUGUI textCoin;

    public void OnInit(int cost)
    {
        SetButtonCost(cost);
    }
    
    public void SetButtonCost(int cost)
    {
        SaveShopData.Instance.SetCost(cost);
        textCoin.text = cost.ToString();
    }
    public void BuyButton()
    {
        CanvasShop canvas = UIManager.Instance.GetUI<CanvasShop>();
        canvas.BuyItem(canvas.TF);
    }
    
    public void SetItemBuy()
    {
        
    }
}

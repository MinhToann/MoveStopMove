using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonTemplate : ItemTemplate
{
    [SerializeField] TextMeshProUGUI titleButton;
    [SerializeField] Image image;
    [SerializeField] ItemType type;
    [SerializeField] int costButton;

    public void SetValueButton(ItemType type, ShopItemType shopType, ItemState itemState,int cost, string name, Sprite image)
    {
        titleButton.text = name;
        this.image.sprite = image;
        SetValue(type, shopType, itemState, cost, name, image);
    }   
    public void SetCostButton()
    {
        CanvasShop canvas = UIManager.Instance.GetUI<CanvasShop>();
        canvas.SetCostButton(this);
    }
    public void AddBuyButton()
    {
        CanvasShop canvas = UIManager.Instance.GetUI<CanvasShop>();
        canvas.AddBuyButton();
    }
    public void EquippedBuyButton()
    {
        CanvasShop canvas = UIManager.Instance.GetUI<CanvasShop>();
        canvas.EquippedBuyButton();
    }
}

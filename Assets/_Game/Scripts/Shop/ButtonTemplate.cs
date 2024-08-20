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
        ItemTemplate currentTemplate = this;
        SaveShopData.Instance.GetItemTemplate(currentTemplate);
        if (SavePlayerData.Instance.playerData.coin >= currentTemplate.costItem)
        {
            canvas.InitBuyBtn(costItem, canvas.tfPanel);
        }
        if (SavePlayerData.Instance.playerData.coin < currentTemplate.costItem)
        {
            canvas.NotEnoughMoney(costItem, canvas.tfPanel);
            
        }
        if (SaveShopData.Instance.shopData.listItemUnlocked.Contains(currentTemplate.shopType))
        {
            canvas.BuyItem(canvas.tfPanel);
        }
        if (SaveShopData.Instance.shopData.listItemEquipped.Contains(currentTemplate.shopType))
        {
            canvas.EquippedItem(canvas.tfPanel);
        }
    }
    public void AddBuyButton()
    {
        CanvasShop canvas = UIManager.Instance.GetUI<CanvasShop>();
        ItemTemplate currentTemplate = SaveShopData.Instance.LoadData().currentItem;
        currentTemplate.itemState = ItemState.Unlocked;
        SaveShopData.Instance.AddListItemUnlock(currentTemplate.shopType);
        //if (UIManager.Instance.IsOpened<CanvasHatShop>())
        //{
        //    ShopManager.Instance.CreateItem(ItemType.Hat, UIManager.Instance.GetUI<CanvasHatShop>().SetParent());
        //}
        //else if (UIManager.Instance.IsOpened<CanvasPantShop>())
        //{
        //    ShopManager.Instance.CreateItem(ItemType.Pant, UIManager.Instance.GetUI<CanvasPantShop>().SetParent());
        //}
        //else if (UIManager.Instance.IsOpened<CanvasSkinShop>())
        //{
        //    ShopManager.Instance.CreateItem(ItemType.Pant, UIManager.Instance.GetUI<CanvasSkinShop>().SetParent());
        //}
        //canvas.InitBuyBtn(costItem, canvas.tfPanel);
        SavePlayerData.Instance.DecreaseCoin(currentTemplate.costItem);
        canvas.BuyItem(canvas.tfPanel);
    }
    public void EquippedBuyButton()
    {
        CanvasShop canvas = UIManager.Instance.GetUI<CanvasShop>();
        ItemTemplate currentTemplate = SaveShopData.Instance.LoadData().currentItem;
        currentTemplate.itemState = ItemState.Equipped;
        
        for (int i = 0; i < SaveShopData.Instance.shopData.listItemEquipped.Count; i++)
        {
            for(int j = 0; j < SaveShopData.Instance.shopData.listItemTemplateEquipped.Count; j++)
            {
                if (currentTemplate.itemType == SaveShopData.Instance.shopData.listItemTemplateEquipped[j])
                {
                    SaveShopData.Instance.shopData.listItemTemplateEquipped.RemoveAt(j);
                    SaveShopData.Instance.RemoveItemEquipped(SaveShopData.Instance.shopData.listItemEquipped[j]);
                }
                
            }
            

        }

        SaveShopData.Instance.AddItemEquipped(currentTemplate.itemType);
        SaveShopData.Instance.AddListItemEquipped(currentTemplate.shopType);
        canvas.EquippedItem(canvas.tfPanel);

        
        if(SaveShopData.Instance.shopData.listItemEquipped.Contains(currentTemplate.shopType))
        {
            if (currentTemplate.itemType == ItemType.Weapon)
            {
                SavePlayerData.Instance.SetWeaponItem(currentTemplate.shopType);
                LevelManager.Instance.getPlayer.SpawnWeapon();
            }
            if (currentTemplate.itemType == ItemType.Hat)
            {
                SavePlayerData.Instance.SetHatItem(currentTemplate.shopType);
                LevelManager.Instance.getPlayer.SpawnHat();
            }
        }
    }
}

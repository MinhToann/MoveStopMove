using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CanvasShop : UICanvas
{
    [field: SerializeField] public List<ButtonControl> listButtonControl { get; private set; } = new List<ButtonControl>();
    [field: SerializeField] public Transform tfPanel { get; private set; }
    private ButtonControl currentButton;
    [SerializeField] NewItemDataSO newItemDataSO;

    public override void Setup()
    {
        base.Setup();
        //doc data

        //sinh ra button
        InitBuyBtn(0, tfPanel);

        //-> truyen oninit
    }
    public override void Open()
    {
        base.Open();
        LevelManager.Instance.DeactiveJoyStick();
        gameState = GameState.Shop;
        LevelManager.Instance.SetStateCamera(gameState);       
        //changeCamState.ChangeAnim(Const.ANIM_SHOPPINGVIEW);
    }
    public void InitBuyBtn(int cost, Transform tf)
    {
        if (currentButton != null)
        {
            Destroy(currentButton.gameObject);
        }
        currentButton = Instantiate(listButtonControl[0], tf);
        currentButton.OnInit(cost);
    }
    public void OpenCanvasHat()
    {
        UIManager.Instance.OpenUI<CanvasHatShop>().TF.SetParent(TF);
        UIManager.Instance.CloseUI<CanvasPantShop>(0.1f);
        UIManager.Instance.CloseUI<CanvasSkinShop>(0.1f);
        ShopManager.Instance.CreateItem(ItemType.Hat, UIManager.Instance.GetUI<CanvasHatShop>().SetParent());
        Setup();
    }

    public void OpenCanvasPant()
    {
        UIManager.Instance.OpenUI<CanvasPantShop>().TF.SetParent(TF);
        UIManager.Instance.CloseUI<CanvasHatShop>(0.1f);
        UIManager.Instance.CloseUI<CanvasSkinShop>(0.1f);
        ShopManager.Instance.CreateItem(ItemType.Pant, UIManager.Instance.GetUI<CanvasPantShop>().SetParent());
        Setup();
    }
    public void OpenCanvasSkin()
    {
        UIManager.Instance.OpenUI<CanvasSkinShop>().TF.SetParent(TF);
        UIManager.Instance.CloseUI<CanvasHatShop>(0.1f);
        UIManager.Instance.CloseUI<CanvasPantShop>(0.1f);
        ShopManager.Instance.CreateItem(ItemType.Weapon, UIManager.Instance.GetUI<CanvasSkinShop>().SetParent());
        Setup();
    }
    public void ExitShop()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }

    public void BuyItem(Transform tf)
    {
        if (currentButton != null)
        {
            Destroy(currentButton.gameObject);
        }
        if(currentButton == listButtonControl[0])
        {
            Destroy(currentButton.gameObject);
        }
        currentButton = Instantiate(listButtonControl[1], tf);
    }

    public void EquippedItem(Transform tf)
    {
        if (currentButton != null)
        {
            Destroy(currentButton.gameObject);
        }
        currentButton = Instantiate(listButtonControl[2], tf);
    }
    public void NotEnoughMoney(int cost, Transform tf)
    {
        if (currentButton != null)
        {
            Destroy(currentButton.gameObject);
        }
        currentButton = Instantiate(listButtonControl[3], tf);
        currentButton.OnInit(cost);
    }

    public void SetCostButton(ItemTemplate currentItem)
    {
        ItemTemplate currentTemplate = currentItem;
        SaveShopData.Instance.GetItemTemplate(currentTemplate);
        if (SavePlayerData.Instance.playerData.coin >= currentTemplate.costItem)
        {
            InitBuyBtn(currentTemplate.costItem, tfPanel);
        }
        if (SavePlayerData.Instance.playerData.coin < currentTemplate.costItem)
        {
            NotEnoughMoney(currentTemplate.costItem, tfPanel);

        }
        if (SaveShopData.Instance.shopData.listItemUnlocked.Contains(currentTemplate.shopType))
        {
            BuyItem(tfPanel);
        }
        if (SaveShopData.Instance.shopData.listItemEquipped.Contains(currentTemplate.shopType))
        {
            EquippedItem(tfPanel);
        }
    }
    public void AddBuyButton()
    {
        ItemTemplate currentTemplate = SaveShopData.Instance.LoadData().currentItem;
        currentTemplate.itemState = ItemState.Unlocked;
        SaveShopData.Instance.AddListItemUnlock(currentTemplate.shopType);
        SavePlayerData.Instance.DecreaseCoin(currentTemplate.costItem);
        BuyItem(tfPanel);
    }
    public void EquippedBuyButton()
    {
        ItemTemplate currentTemplate = SaveShopData.Instance.LoadData().currentItem;
        currentTemplate.itemState = ItemState.Equipped;

        for (int i = 0; i < SaveShopData.Instance.shopData.listItemEquipped.Count; i++)
        {
            for (int j = 0; j < SaveShopData.Instance.shopData.listItemTemplateEquipped.Count; j++)
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
        EquippedItem(tfPanel);


        if (SaveShopData.Instance.shopData.listItemEquipped.Contains(currentTemplate.shopType))
        {
            if (currentTemplate.itemType == ItemType.Weapon)
            {
                SavePlayerData.Instance.SetWeaponItem(currentTemplate.shopType);
                LevelManager.Instance.getPlayer.SpawnWeapon();
                LevelManager.Instance.getPlayer.SetAnimatorCharacter();
            }
            if (currentTemplate.itemType == ItemType.Hat)
            {
                SavePlayerData.Instance.SetHatItem(currentTemplate.shopType);
                LevelManager.Instance.getPlayer.SpawnHat();
            }
        }
    }
}

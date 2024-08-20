using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEditor;


public class SaveShopData : Singleton<SaveShopData>
{
    
    const string Path = "ShopItemData.abc";
    public ShopData shopData = new ShopData();
    private void Awake()
    {
        shopData = LoadData();
    }
    public void SaveData()
    {
        SaveGame.Save(Path, shopData);
    }    
    public ShopData LoadData()
    {
        return SaveGame.Load(Path, new ShopData());
    }    
    public void SetCost(int cost)
    {
        shopData.SetCost(cost);
        SaveData();
    }    
    public void AddListItemUnlock(ShopItemType itemType)
    {
        shopData.AddItemUnlocked(itemType);        
        SaveData();
    }
    public void AddListItemEquipped(ShopItemType itemType)
    {
        shopData.AddItemEquipped(itemType);
        SaveData();
    }

    public void RemoveItemEquipped(ShopItemType shopType)
    {
        shopData.RemoveItemEquipped(shopType);
        SaveData();
    }
    public void GetItemTemplate(ItemTemplate item)
    {
        shopData.GetCurItem(item);
        SaveData();
    }    
    public void AddItemEquipped(ItemType item)
    {
        shopData.AddItemEquipped(item);
        SaveData();
    }
}
[System.Serializable]
public class ShopData
{

    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public List<ShopItemType> listItemUnlocked { get; private set; } = new List<ShopItemType>();
    [field: SerializeField] public List<ShopItemType> listItemEquipped { get; private set; } = new List<ShopItemType>();
    [field: SerializeField] public List<ItemType> listItemTemplateEquipped { get; private set; } = new List<ItemType>();

    private ItemTemplate itemTemplate;
    [field: SerializeField] public ItemTemplate currentItem { get; private set; }
    public void SetCost(int costItem)
    {
        Cost = costItem;
    }
    public ItemTemplate item => itemTemplate;
    public void AddItemUnlocked(ShopItemType shopType)
    {
        listItemUnlocked.Add(shopType);
    }
    public void AddItemEquipped(ShopItemType shopType)
    {
        listItemEquipped.Add(shopType);
        listItemUnlocked.Remove(shopType);
    }
    public void RemoveItemEquipped(ShopItemType shopType)
    {
        listItemEquipped.Remove(shopType);
        listItemUnlocked.Add(shopType);
    }
    public void AddItemEquipped(ItemType item)
    {
        listItemTemplateEquipped.Add(item);
    }

    public void GetCurItem(ItemTemplate item)
    {
        currentItem = item;
    }

    public ShopData()
    {
        SetCost(0);
        itemTemplate = null;
    }
    
}

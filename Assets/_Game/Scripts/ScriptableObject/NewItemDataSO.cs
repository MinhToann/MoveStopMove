using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "ItemSO")]
public class NewItemDataSO : ScriptableObject
{
    [field: SerializeField] public List<ItemTemplate> templateItemList { get; private set; }

    public int listTemplateCount => templateItemList.Count;


    public int GetItemCost(ItemType itemType)
    {
        return templateItemList[(int)itemType].costItem;
    }
    public string GetItemName(ItemType itemType)
    {
        return templateItemList[(int)itemType].titleName;
    }
    public Sprite GetItemImage(ItemType itemType)
    {
        return templateItemList[(int)itemType].imgItem;
    }

    public ItemType SetItemType(int index)
    {
        return templateItemList[index].itemType;
    }
    public ShopItemType SetShopItemType(int index)
    {
        return templateItemList[index].shopType;
    }    
    public ItemState SetItemState(int index)
    {
        return templateItemList[index].itemState;
    }    
    public int GetItemCost(int index)
    {
        return templateItemList[index].costItem;
    }
    public string GetItemName(int index)
    {
        return templateItemList[index].titleName;
    }
    public Sprite GetItemImage(int index)
    {
        return templateItemList[index].imgItem;
    }
    public void SetInfo(ItemType type)
    {
        GetItemCost(type);
        GetItemName(type);
        GetItemImage(type);
    }
  
}


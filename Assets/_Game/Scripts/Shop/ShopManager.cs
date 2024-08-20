using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] NewItemDataSO itemSO;
    [field: SerializeField] public List<ItemTemplate> listItem { get; private set; } = new List<ItemTemplate>();
    [SerializeField] ButtonTemplate buttonTemplate; 
    public void CreateItem(ItemType itemType, Transform tf)
    {
        if (listItem.Count > 0)
        {
            ClearItem();
        }
        for (int i = 0; i < itemSO.listTemplateCount; i++)
        {
            ButtonTemplate button = Instantiate(buttonTemplate);
            button.SetValueButton(itemSO.SetItemType(i), itemSO.SetShopItemType(i), itemSO.SetItemState(i),itemSO.GetItemCost(i), itemSO.GetItemName(i), itemSO.GetItemImage(i));
            
            //SaveShopData.Instance.AddListItemBuy(button);
            if (button.itemType == itemType)
            {
                button.TF.SetParent(tf);
                AddItem(button);
            }
            else
            {
                Destroy(button.gameObject);
                RemoveItem(button);
            }
        }
    }
    public void AddItem(ItemTemplate item)
    {
        listItem.Add(item);
    }
    public void RemoveItem(ItemTemplate item)
    {
        listItem.Remove(item);
    }
    public void ClearItem()
    {
        foreach(var item in listItem)
        {
            Destroy(item.gameObject);
        }
        listItem.Clear();
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTemplate : MonoBehaviour
{
    [field: SerializeField] public ItemType itemType { get; private set; }

    [field: SerializeField] public ShopItemType shopType { get; private set; } 
    [field: SerializeField] public int costItem { get; private set; }
    [field: SerializeField] public string titleName { get; private set; }
    [field: SerializeField] public Sprite imgItem { get; private set; }

    public ItemState itemState;
    public ItemType Type => itemType;
    public int Cost => costItem;
    public string Title => titleName;
    public Sprite Image => imgItem;

    private Transform tf;
    public Transform TF
    {
        get
        {
            if (tf == null)
            {
                tf = transform;
            }
            return tf;
        }
    }
    public void SetValue(ItemType itemType, ShopItemType shopType, ItemState itemState,int cost, string name, Sprite image)
    {
        this.itemType = itemType;
        this.shopType = shopType;
        this.itemState = itemState;
        costItem = cost;
        titleName = name;
        imgItem = image;
    }
}

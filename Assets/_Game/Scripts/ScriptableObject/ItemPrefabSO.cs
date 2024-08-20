using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Prefab")]
public class ItemPrefabSO : ScriptableObject
{
    public ItemTemplate[] items;
    [SerializeField] HatTemplate[] hatsPrefab;
    [SerializeField] PantTemplate[] pantsPrefab;
    [field: SerializeField] public WeaponBase[] weaponsPrefab { get; private set; }

    public ItemTemplate ChangeItem(ItemType itemType)
    {
        return items[(int)itemType];
    }

    public HatTemplate ChangeHatItem(ShopItemType itemType)
    {
        HatTemplate hatTemp = new HatTemplate();
        for (int i = 0; i < hatsPrefab.Length; i++)
        {
            if (hatsPrefab[i].shopType == itemType)
            {
                hatTemp = hatsPrefab[i];
            }
        }
        return hatTemp;


    }
    public PantTemplate ChangePantItem(ShopItemType itemType)
    {
        PantTemplate pantTemp = new PantTemplate();
        for (int i = 0; i < pantsPrefab.Length; i++)
        {
            if (pantsPrefab[i].shopType == itemType)
            {
                pantTemp = pantsPrefab[i];
            }
        }
        return pantTemp;

       
    }
    public WeaponBase ChangeWeaponItem(ShopItemType itemType)
    {
        WeaponBase weaponTemp = new WeaponBase();
        for (int i = 0; i < weaponsPrefab.Length; i++)
        {
            if (weaponsPrefab[i].shopType == itemType)
            {
                weaponTemp = weaponsPrefab[i];
            }
        }
        return weaponTemp;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
public class SavePlayerData : Singleton<SavePlayerData>
{
    // Start is called before the first frame update
    public PlayerData playerData = new PlayerData();
    //string dataPath = "data.abc";
    const string Path = "PlayerItemData.lol";

    private void Awake()
    {       
        playerData = LoadData();
    }
    public void SaveData()
    {
        SaveGame.Save(Path, playerData);
    }
    public PlayerData LoadData()
    {
        return SaveGame.Load(Path, new PlayerData());
    }
    public void IncreaseCoin(int coin)
    {
        playerData.coin += coin;
        SaveData();
    }
    public void DecreaseCoin(int coin)
    {
        playerData.coin -= coin;
        SaveData();
    }
    public void SetCoin()
    {
        playerData.coin = 0;
        SaveData();
    }
    public void SetWeaponItem(ShopItemType itemType)
    {
        playerData.SetWeaponItem(itemType);
        SaveData();
    }
    public void SetHatItem(ShopItemType itemType)
    {
        playerData.SetHatItem(itemType);
        SaveData();
    }
    public void SetPantItem(ShopItemType itemType)
    {
        playerData.SetPantItem(itemType);
        SaveData();
    }
}
[System.Serializable]
public class PlayerData
{
    
    public CharacterModel playerModel;
    public List<CharacterModel> characterModels = new List<CharacterModel>();
    public List<WeaponType> listWeapons = new List<WeaponType>();
    public int coin;
    [field: SerializeField] public ShopItemType hatType { get; private set; }
    [field: SerializeField] public ShopItemType pantType { get; private set; }
    [field: SerializeField] public ShopItemType weaponType { get; private set; }
    public PlayerData()
    {
        hatType = ShopItemType.Xmas;
        pantType = ShopItemType.GreenPant;
        weaponType = ShopItemType.Daggers;

        playerModel = CharacterModel.Boy;
        coin = 0;
    }
    
    public void SetHatItem(ShopItemType hatType)
    {
        this.hatType = hatType;
    }
    public void SetPantItem(ShopItemType pantType)
    {
        this.pantType = pantType;
    }
    public void SetWeaponItem(ShopItemType weaponType)
    {
        this.weaponType = weaponType;
    }
}

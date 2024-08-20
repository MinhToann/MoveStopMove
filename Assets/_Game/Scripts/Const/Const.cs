using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    bot = 0
}
public enum BotType
{
    Boy = 0,
    Girl = 1,
    Grandfather = 2,
    Hero = 3,
    Ninja = 4
}
public enum WeaponType
{
    Axe = 0,
    Mace = 1,
    Staff = 2,
    Wand = 3,
    Sword = 4,
    Hammer = 5,
    Daggers = 6,
    None = 7
}

public enum GameState
{
    MainMenu = 0,
    GamePlay = 1,
    Victory = 2,
    Lose = 3,
    Shop = 4,
    ShopHat = 5,
    ShopPant = 6,
    ShopWeapon = 7,
    BuyItem = 8
}
public enum ItemType
{
    Hat = 0,
    Pant = 1,
    Weapon = 2
}
public enum ShopItemType
{
    Pirate = 1,
    Chef = 2,
    Sombrero = 3,
    WhiteHat = 4,
    Witch = 5,
    Birthday = 6,
    Xmas = 7,

    Mickey = 11,
    GreenPant = 12,
    WhitePant = 13,
    BlackPant = 14,
    LongBlue = 15,
    LongBrown = 16,

    Axe = 20,
    Mace = 21,
    Staff = 22,
    Wand = 23,
    Sword = 24,
    Hammer = 25,
    Daggers = 26,
   
}
public enum ItemState
{
    Unbuy = 0,
    Buy = 1,
    Unlocked = 2,
    Equipped = 3
}
public enum CameraState
{
    GamePlay = 0,
    Shopping = 1
}
public enum CharacterModel
{
    Boy = 0
}
public class Const : MonoBehaviour
{
    public const string ANIM_IDLE = "Idle";
    public const string ANIM_RUN = "Run";
    public const string ANIM_DEATH = "Death";
    public const string ANIM_THROW = "Throw";
    public const string ANIM_DANCE = "Dance";
    public const string ANIM_SLASH = "Slash";
    public const string ANIM_FIREMAGIC = "Magic";
    public const string ANIM_SHOPPINGVIEW = "ShoppingView";
    public const string ANIM_NORMALVIEW = "NormalView";
}

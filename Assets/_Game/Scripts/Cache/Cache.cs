using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache 
{
    private static Dictionary<Collider, Character> dicCharacter = new Dictionary<Collider, Character>();

    private static Dictionary<Collider, GameUnit> dicWeapon = new Dictionary<Collider, GameUnit>();
    public static Character ChaCollider(Collider collider)
    {
        if(!dicCharacter.ContainsKey(collider))
        {
            Character cha = collider.GetComponent<Character>();
            dicCharacter.Add(collider, cha);
        }
        return dicCharacter[collider];
    }

    public static GameUnit WeaponCollider(Collider collider)
    {
        if (!dicWeapon.ContainsKey(collider))
        {
            GameUnit weapon = collider.GetComponent<GameUnit>();
            dicWeapon.Add(collider, weapon);
        }
        return dicWeapon[collider];
    }
}

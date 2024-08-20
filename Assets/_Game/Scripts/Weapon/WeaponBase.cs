using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class WeaponBase : ItemTemplate
{
    [SerializeField] Pool pool;
    Character character;
    public Transform bulletPoint;
    public void SpawnBullet()
    {       
        BulletBase bullet = SimplePool.Spawn<BulletBase>(shopType, bulletPoint.position, character.TF.rotation);
        bullet.SetCharacter(character);
    }    
    public void SetCharacter(Character character)
    {
        this.character = character;
    }    

}

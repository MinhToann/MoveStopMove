using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : GameUnit
{
    Character character;
    [SerializeField] private float throwSpeed = 3f;

    void Update()
    {
        ThrowForward();
    }
    public void SetCharacter(Character character)
    {
        this.character = character;
    }    
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
    public bool IsCheckPlayer()
    {
        if(character is Player)
        {
            return true;
        }
        else return false;
    }    
    public virtual void ThrowForward()
    {
        TF.position += TF.forward * throwSpeed * Time.deltaTime;   
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if(Cache.ChaCollider(other))
        {            
            if (Cache.ChaCollider(other) != character)
            {                
                Cache.ChaCollider(other).OnHit(100);                
                OnDespawn();
                character.UpdateAttackSize();
            }
            if(character is Player && Cache.ChaCollider(other) is Bot)
            {
                Debug.Log("+1");
                SavePlayerData.Instance.IncreaseCoin(1);
                UIManager.Instance.GetUI<CanvasMainMenu>().SetCoin();
            }        
        }
        if(other.CompareTag("Wall"))
        {
            OnDespawn();
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Sphere"))
        {
            OnDespawn();
        }
    }


}

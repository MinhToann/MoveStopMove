using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCollider : MonoBehaviour
{
    [SerializeField] private Character character;
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
    private void OnTriggerEnter(Collider other)
    {
        if(Cache.ChaCollider(other))
        {        
            character.SetTarget(Cache.ChaCollider(other));
            character.AddListCharacter(Cache.ChaCollider(other));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Cache.ChaCollider(other))
        {
            //character.SetTarget(null);
            character.RemoveCharacter(Cache.ChaCollider(other));
        }
    }
}

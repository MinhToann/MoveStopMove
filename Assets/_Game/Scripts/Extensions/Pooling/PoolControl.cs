using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolControl : MonoBehaviour
{
    //[SerializeField] private PoolAmout[] poolAmout;
    private void Awake()
    {
        GameUnit[] gameUnits = Resources.LoadAll<GameUnit>("Pool/");
        //load tu resources
        for (int i = 0; i < gameUnits.Length; i++)
        {
            SimplePool.Preload(gameUnits[i], 0, transform);
        }
    }
}
//[System.Serializable]
//public class PoolAmout
//{
//    public GameUnit prefab;
//    public int amount;
//    public Transform parent;
//}


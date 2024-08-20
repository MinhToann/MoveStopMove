using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] Player player;
    void Start()
    {
        
    }
    public void OnInit()
    {
        Player newPlayer = Instantiate(player);
        newPlayer.OnInit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

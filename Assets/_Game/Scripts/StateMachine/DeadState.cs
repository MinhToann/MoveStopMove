using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeadState : IState<Bot>
{
    public void OnEnter(Bot bot)
    {
        bot.OnDeath();      
    }
    public void OnExecute(Bot bot)
    {

    }
    public void OnExit(Bot bot)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    float timer;
    float randomTime;
    public void OnEnter(Bot bot)
    {
        randomTime = Random.Range(1.5f, 3);
        bot.OnIdle();
    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if(timer > randomTime)
        {
            bot.ChangeState(new PatrolState());
        }
    }
    public void OnExit(Bot bot)
    {

    }
    
}

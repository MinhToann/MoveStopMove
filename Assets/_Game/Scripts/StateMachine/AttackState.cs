using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
    float timer;
    float randomTime;
    public void OnEnter(Bot bot)
    {       
        randomTime = Random.Range(2, 3);
        timer = 0;
        if(bot.Target != null)
        {
            bot.OnIdle();
            bot.StopMove();
            bot.Attack();
        }           
    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if(bot.Target != null)
        {
            bot.RotateToTarget();
            if (timer > randomTime)
            {
                bot.ChangeState(new PatrolState());
                //bot.isInRange = false;
            }
        }
        else if(bot.Target == null || bot.Target.isDeath)
        {
            bot.ChangeState(new PatrolState());
        }
    }
    public void OnExit(Bot bot)
    {

    }
}

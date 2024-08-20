using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    float timer = 0;
    float randomTime;
    public void OnEnter(Bot bot)
    {
        randomTime = Random.Range(3, 5);
        Vector3 destination;
        destination = LevelManager.Instance.RandomPositionOnFloor();
        bot.SetDestination(destination);
    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if (bot.Target != null)
        {
            if(bot.IsTargetInRange() && !bot.Target.isDeath)
            {
                //bot.StopMove();
                bot.ChangeState(new AttackState());
            }    
        }    
        else
        {
            if (timer > randomTime)
            {
                bot.StopMove();
                bot.ChangeState(new IdleState());
            }  
            if(bot.isDestination)
            {
                Vector3 destination;
                destination = LevelManager.Instance.RandomPositionOnFloor();
                bot.SetDestination(destination);
            }
        }    
        
    }
    public void OnExit(Bot bot)
    {

    }
}

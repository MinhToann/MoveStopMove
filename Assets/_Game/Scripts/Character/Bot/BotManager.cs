using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BotManager : Singleton<BotManager>
{
    [SerializeField] List<Bot> listBots = new List<Bot>();
    [SerializeField] Bot bot;
    public int botQuantity;
    int index;
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
    public void OnInit()
    {
        Spawn();
    }
    
    public void Spawn()
    {
        for (int i = 0; i < 7; i++)
        {
            Bot b = Instantiate(bot, TF);
            b.CreateBotModel();
            b.TF.position = LevelManager.Instance.RandomPositionOnFloor();
            listBots.Add(b);
        }
    }
    public int GetBotCount()
    {
        return listBots.Count;
    }
    public void OnBotDeath(Bot bot)
    {
        listBots.Remove(bot);
        Destroy(bot.gameObject);
    }
    public void ClearAllBot()
    {
        foreach(var bot in listBots)
        {
            Destroy(bot.gameObject);
        }
        listBots.Clear();
    }
}

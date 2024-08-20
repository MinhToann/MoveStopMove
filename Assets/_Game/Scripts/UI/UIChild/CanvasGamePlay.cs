using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] TextMeshProUGUI textAliveNumber;
    [field: SerializeField] public int aliveNumber { get; private set; }
    public override void Open()
    {
        base.Open();
        LevelManager.Instance.ActiveJoyStick();
        gameState = GameState.GamePlay;
        aliveNumber = BotManager.Instance.GetBotCount() + 1;
        SetTextAlive(aliveNumber);
    }
    public void SettingButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    public void SetTextAlive(int numberAlive)
    {
        textAliveNumber.text = numberAlive.ToString();
    }

    public void SetNumberAlive()
    {
        UIManager.Instance.GetUI<CanvasDefeat>().SetTextAlive(aliveNumber);
        aliveNumber = PlayerPrefs.GetInt("number", 0);
    }
    public void SaveNumberAlive()
    {
        aliveNumber--;
        PlayerPrefs.SetInt("number", aliveNumber);
        SetTextAlive(aliveNumber);
        //UIManager.Instance.GetUI<CanvasDefeat>().SetTextAlive(aliveNumber + 1);
    }
}

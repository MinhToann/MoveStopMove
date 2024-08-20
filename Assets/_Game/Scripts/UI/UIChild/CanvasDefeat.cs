using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasDefeat : UICanvas
{
    [SerializeField] TextMeshProUGUI textAliveNumber;
    [SerializeField] TextMeshProUGUI textNameKilled;
    public override void Open()
    {
        base.Open();
        LevelManager.Instance.DeactiveJoyStick();
        gameState = GameState.Lose;
        UIManager.Instance.CloseUI<CanvasGamePlay>(0.1f);
    }
    public void ButtonContinue()
    {
        Close(0);
        LevelManager.Instance.ReloadLevel();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    public void SetTextAlive(int numberAlive)
    {
        textAliveNumber.text = numberAlive.ToString();
    }
    public void SetTextName(string name)
    {
        textNameKilled.text = name;
    } 
}

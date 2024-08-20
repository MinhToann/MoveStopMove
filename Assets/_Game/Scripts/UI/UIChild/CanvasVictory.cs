using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVictory : UICanvas
{
    public override void Open()
    {
        base.Open();
        LevelManager.Instance.DeactiveJoyStick();
        gameState = GameState.Victory;
        UIManager.Instance.CloseUI<CanvasGamePlay>(0.1f);
    }
    public void ButtonContinue()
    {
        Close(0);
        //LevelManager.Instance.ReloadLevel();
        LevelManager.Instance.NextLevel();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        //LevelManager.Instance.ReloadLevel();
    }
}

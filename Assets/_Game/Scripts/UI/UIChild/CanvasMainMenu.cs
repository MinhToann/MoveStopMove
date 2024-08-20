using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasMainMenu : UICanvas
{
    [SerializeField] TextMeshProUGUI textCoin;

    public override void Open()
    {
        base.Open();
        LevelManager.Instance.DeactiveJoyStick();
        SetCoin();
        gameState = GameState.MainMenu;        
        LevelManager.Instance.SetStateCamera(gameState);
    }
    public void PlayButton()
    {
        Close(0);       
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        
    }
    public void OpenShop()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasShop>();
    }
    public void SetCoin()
    {
        textCoin.text = SavePlayerData.Instance.LoadData().coin.ToString();
    }    
}

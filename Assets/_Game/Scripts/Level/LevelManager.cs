using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] List<Level> Listlevels;
    [SerializeField] Player player;
    [field: HideInInspector] public Player getPlayer { get; private set; }
    private Level curLevel;
    int currentLevel = 0;
    [SerializeField] JoystickControl joystickControl;
    [SerializeField] ChangeCameraState changeCamState;
    [SerializeField] List<CinemachineVirtualCamera> cameraVirtual;

    void Start()
    {
        OnLoadLevel(currentLevel);
        OnInit();
        
    }
    public void OnInit()
    {      
        SpawnPlayer();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        BotManager.Instance.OnInit();       
    }       
    public void SpawnPlayer()
    {
        if (getPlayer != null)
        {
            Destroy(getPlayer.gameObject);
        }
        getPlayer = Instantiate(player);
        getPlayer.InitPlayer();
        getPlayer.TF.position = curLevel.GetStartPosition();
    }    
    public Vector3 RandomPositionOnFloor()
    {
        return curLevel.GetRandomPosition();
    }    
    public void ActiveJoyStick()
    {
        joystickControl.gameObject.SetActive(true);
    }
    public void DeactiveJoyStick()
    {
        joystickControl.gameObject.SetActive(false);
    }
    public void ReloadLevel()
    {
        OnLoadLevel(currentLevel);
        BotManager.Instance.ClearAllBot();
        OnInit();
    }
    public void NextLevel()
    {
        OnLoadLevel(++currentLevel);
        BotManager.Instance.ClearAllBot();
        OnInit();
    }
    public void EndLevel()
    {
        OnLoadLevel(0);
        BotManager.Instance.ClearAllBot();
        OnInit();
    }
    private void OnLoadLevel(int level)
    {
        if (curLevel != null)
        {
            Destroy(curLevel.gameObject);
        }    
        if(level < Listlevels.Count)
        {
            curLevel = Instantiate(Listlevels[level]);
        }
    }
    public void SetStateCamera(GameState gameState)
    {    
        switch (gameState)
        {  
            case GameState.MainMenu:
                CloseCamVirtual();
                cameraVirtual[0].Priority = 10;
                break;
            case GameState.Shop:
                CloseCamVirtual();
                cameraVirtual[1].Priority = 10;
                break;
        }    
    }    
    private void CloseCamVirtual()
    {
        for(int i = 0; i < cameraVirtual.Count; i++)
        {
            cameraVirtual[i].Priority = 1;
        }    
    }    
}

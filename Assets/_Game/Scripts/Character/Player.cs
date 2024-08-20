using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    private JoystickControl joys;
    [SerializeField] PlayerModel playerModels;
    [SerializeField] List<AnimatorOverrideController> listOverrideAnimators = new List<AnimatorOverrideController>();
    private float moveSpeed = 5f;
    private PlayerModel model;
    private void Awake()
    {
        joys = GetComponent<JoystickControl>();
    }
    public override void OnInit()
    {
        base.OnInit();  
    }
    public void InitPlayer()
    {
        SpawnModel();
        OnInit();
        SpawnWeapon();
        SpawnHat();
        //SpawnPant(playerModel.Legs);
    }
    public void SpawnModel()
    {
        model = Instantiate(playerModels, TF);
        characterAnim = model.GetAnimator();
    }    

    public void GetAnimator(Animator animator)
    {
        characterAnim = animator;
    }    
    public void SpawnHat()
    {
        ChangeHatItem(SavePlayerData.Instance.LoadData().hatType, model.Head);

    }
    //void SpawnPant(Transform transform)
    //{
    //    ChangePantItem(SavePlayerData.Instance.LoadData().pantType, transform);
    //}
    public void SpawnWeapon()
    {
        ChangeWeapon(SavePlayerData.Instance.LoadData().weaponType, model.leftHand);
    }
    public void DanceAnim()
    {
        ChangeAnim(Const.ANIM_DANCE);
        Debug.Log("Dance");
    }    

    public override void Update()
    {
        base.Update();
        if (UIManager.Instance.IsOpened<CanvasGamePlay>())
        {
            //joys.gameObject.SetActive(true);
            //UIManager.Instance.OpenUI<JoystickControl>();
            Movement();
            if (isDeath)
            {
                
                OnDeath();
                
            }
            if (BotManager.Instance.GetBotCount() <= 0)
            {
                Invoke(nameof(OnVictory), 0.3f);
            }
        }  
        if(UIManager.Instance.IsOpened<CanvasShop>())
        {
            DanceAnim();
        }
        else if (UIManager.Instance.IsOpened<CanvasMainMenu>())
        {
            OnIdle();
        }
    }
    public override void Throw()
    {
        base.Throw();        
        //weaponDataSO.GetWeapon(weaponType).SpawnBullet(spawnPosWeapon);
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        //LevelManager.Instance.gameState = GameState.Lose;
        UIManager.Instance.OpenUI<CanvasDefeat>().SetTextAlive(UIManager.Instance.GetUI<CanvasGamePlay>().aliveNumber + 1);
        UIManager.Instance.GetUI<CanvasDefeat>().SetTextName(Target.name);
        Destroy(this.gameObject);
    }
    public void OnVictory()
    {
        //UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasVictory>();
        OnIdle();
        
    }
    public override void Attack()
    {
        base.Attack();
        //ChangeAnim(Const.ANIM_THROW);
        switch (SavePlayerData.Instance.LoadData().weaponType)
        {
            case ShopItemType.Sword:
                //model.SetOverrideAnimator(listOverrideAnimators[1]);
                ChangeAnim(Const.ANIM_SLASH);
                break;
            case ShopItemType.Wand:
                //model.SetOverrideAnimator(listOverrideAnimators[2]);
                ChangeAnim(Const.ANIM_FIREMAGIC);
                break;
            case ShopItemType.Staff:
                //model.SetOverrideAnimator(listOverrideAnimators[2]);
                ChangeAnim(Const.ANIM_FIREMAGIC);
                break;
            default:
                //model.SetOverrideAnimator(listOverrideAnimators[0]);
                ChangeAnim(Const.ANIM_THROW);
                break;
        }
        characterAnim = model.GetAnimator();
    }
    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            ChangeAnim(Const.ANIM_RUN);
            rb.velocity = JoystickControl.direct * moveSpeed + rb.velocity.y * Vector3.up;
            rb.rotation = Quaternion.LookRotation(rb.velocity);     
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnIdle();
            rb.velocity = Vector3.zero;
            if (IsTargetInRange())
            {
                OnIdle();
                rb.velocity = Vector3.zero;
                PlayerRotateToTarget();
                Attack();
            }
        }
    }
    
    public void PlayerRotateToTarget()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            TF.LookAt(characterList[i].TF.position);
        }
    }
}

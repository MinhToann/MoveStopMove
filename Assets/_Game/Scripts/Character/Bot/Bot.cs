using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public PoolType poolType;
    [SerializeField] NavMeshAgent agent;
    IState<Bot> currentState;
    Vector3 destination;
    private float rotateSpeed = 3f;
    public bool isDestination => Vector3.Distance(TF.position, destination + (TF.position.y - destination.y) * Vector3.up) < 0.1f;
    [SerializeField] List<BotModel> listModels = new List<BotModel>();
    private BotModel botModel;
    public override void OnInit()
    {
        base.OnInit();      
        ChangeState(new IdleState());
        TF.position = LevelManager.Instance.RandomPositionOnFloor();
    }
    public void CreateBotModel()
    {
        
        int index = Random.Range(0, listModels.Count);
        botModel = Instantiate(listModels[index], TF);
        this.name = listModels[index].name;
        characterAnim = botModel.GetAnimator();
        handHolder = botModel.handHolder;
        ChangeWeapon(ShopItemType.Staff, botModel.handHolder);
        //Change Bot Model Weapon
        ShopItemType weaponType = itemPrefabSO.weaponsPrefab[Random.Range(0, itemPrefabSO.weaponsPrefab.Length)].shopType;
        ChangeWeapon(weaponType, botModel.handHolder);
        SetAnimatorBot(weaponType);
    }
    public void SetAnimatorBot(ShopItemType shopItemType)
    {
        switch (shopItemType)
        {
            case ShopItemType.Sword:
                botModel.SetOverrideAnimator(listOverrideAnimators[1]);
                break;
            case ShopItemType.Wand:
                botModel.SetOverrideAnimator(listOverrideAnimators[2]);
                break;
            case ShopItemType.Staff:
                botModel.SetOverrideAnimator(listOverrideAnimators[2]);
                break;
            case ShopItemType.Hammer:
                botModel.SetOverrideAnimator(listOverrideAnimators[2]);
                break;
            default:
                botModel.SetOverrideAnimator(listOverrideAnimators[0]);
                break;
        }
        characterAnim = botModel.GetAnimator();
    }
    public override void Attack()
    {
        base.Attack();
        //ChangeAnim(Const.ANIM_THROW);
    }
    public override void Throw()
    {
        base.Throw();
        currentWeapon.SpawnBullet();
    }
    public void ChangeState(IState<Bot> state)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
        
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        BotManager.Instance.OnBotDeath(this);
    }
    public override void Update()
    {
        base.Update();
        if(UIManager.Instance.IsOpened<CanvasGamePlay>())
        {
            if(!isDeath)
            {
                if (currentState != null)
                {
                    currentState.OnExecute(this);
                }
            }
            else
            {
                ChangeState(new DeadState());
            }
        }       
        
    }
    public void RotateToTarget()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            Vector3 dir = characterList[i].TF.position - TF.position;
            Quaternion lookRotate = Quaternion.Slerp(TF.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);
            lookRotate.x = 0;
            lookRotate.z = 0;
            TF.rotation = lookRotate;
        }
    }
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        agent.SetDestination(destination);
        ChangeAnim(Const.ANIM_RUN);
    }
    public void StopMove()
    {
        SetDestination(TF.position);
    }    
}

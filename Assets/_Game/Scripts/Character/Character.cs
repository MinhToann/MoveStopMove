using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    public bool isMoving;
    private Transform tf;
    protected float attackRange;
    [SerializeField] RangeCollider rangeCollider;
    
    public bool isInRange = false;
    public bool isStand;
    public Transform bulletPoint;

    private float timer = 0.75f;
    public float Timer => timer;
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
    private string currentAnim;
    [SerializeField] protected Animator characterAnim;
    [SerializeField] protected List<Character> characterList = new List<Character>();
    protected float min;
    private float hp;
    public bool isDeath => hp <= 0;
    protected CounterTime cooldownTime = new CounterTime();
    private Character target;
    public Character Target => target;

    [SerializeField] protected ItemPrefabSO itemPrefabSO;
    protected ItemTemplate currentItem;
    protected WeaponBase currentWeapon;
    protected HatTemplate currentHat;
    protected PantTemplate currentPant;
    public Transform handHolder;
    protected Transform Head;
    protected Transform Underbody;
    [field: SerializeField] public float timerDeath { get; private set; }
    private Vector3 upSizeCollider = new Vector3(0.3f, 0, 0.3f);
    void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        hp = 100f;
        cooldownTime.SetTime(-1f);
        timerDeath = 0f;
        SetSizeAttack();
        ClearListCharacter();
        isInRange = false;
        OnIdle();
    }
    public virtual void OnDespawn()
    {
        CanvasGamePlay gamePlay = UIManager.Instance.GetUI<CanvasGamePlay>();
        gamePlay.SaveNumberAlive();
    }
    public float SetRangeAttack(float attackRange)
    {
        this.attackRange = attackRange;
        return attackRange;
    }    
    public void SetSizeAttack()
    {
        attackRange = 4f;
        rangeCollider.TF.localScale = new Vector3(7f, 0.1f, 7f);
    }    
    public void UpdateAttackSize()
    {
        attackRange += 0.3f;
        rangeCollider.TF.localScale += upSizeCollider;
    }    
    protected void ClearListCharacter()
    {
        characterList.Clear();

    }
 
    public virtual void Update()
    {
        if(UIManager.Instance.IsOpened<CanvasShop>())
        {
            rangeCollider.gameObject.SetActive(false);
        }    
        if (UIManager.Instance.IsOpened<CanvasGamePlay>())
        {
            rangeCollider.gameObject.SetActive(true);
            if (!isDeath)
            {
                cooldownTime.Execute(Time.deltaTime);
                //if(characterList.Count > 0)
                //{
                //    Debug.Log(target.name);
                //}    
                if (target != null)
                {
                    Debug.Log(target.name);
                    if (target.isDeath)
                    {
                        RemoveCharacter(target);

                    }
                }
            }
            else
            {
                cooldownTime.Stop();
                timerDeath += Time.deltaTime;
                //RemoveDeathCharacter();
            }
        }        
    }
    protected void SphereRange()
    {

    }

    public void OnDeath()
    {
        ChangeAnim(Const.ANIM_DEATH);
        if (timerDeath > 2f)
        {
            OnDespawn();
            timerDeath = 0;
        }
    }
    public void AddListCharacter(Character character)
    {
        characterList.Add(character);
    }
    public void RemoveCharacter(Character character)
    {
        characterList.Remove(character);
    }
    public void RemoveDeathCharacter()
    {
        if(target.isDeath)
        {
            characterList.Remove(target);
        }          
    }    
    public void OnIdle()
    {
        ChangeAnim(Const.ANIM_IDLE);
        isStand = true;
    }    
    protected void ChangeAnim(string newAnim)
    {
        if(currentAnim != newAnim)
        {
            characterAnim.ResetTrigger(currentAnim);
            currentAnim = newAnim;
            characterAnim.SetTrigger(currentAnim);
        }
    }
    public void ChangeItemCharacter(ItemType itemType)
    {

    }

    public void ChangeHatItem(ShopItemType hatType, Transform parent)
    {
        if(currentHat != null)
        {
            Destroy(currentHat.gameObject);
        }
        currentHat = Instantiate(itemPrefabSO.ChangeHatItem(hatType), parent);
        currentHat.TF.position = parent.position;
        currentHat.TF.rotation = parent.rotation;
    }    
    public void ChangeWeapon(ShopItemType weaponType, Transform handHolder)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        
        currentWeapon = Instantiate(itemPrefabSO.ChangeWeaponItem(weaponType), handHolder);
        currentWeapon.TF.position = handHolder.position;
        currentWeapon.TF.rotation = handHolder.rotation;
    }

    public virtual void Attack()
    {
        //ChangeAnim(Const.ANIM_THROW);
        cooldownTime.Start(() => Throw(), 0.3f);
    }    

    public virtual void Throw()
    {
        currentWeapon.SetCharacter(this);
        currentWeapon.SpawnBullet();
    }    

    public bool IsTargetInRange()
    {              
        if (target != null)
        {
            CheckTarget();
            return min <= attackRange;
        }
        else return false;
    }

    public void SetTarget(Character character)
    {
        target = character;
    }
    protected void CheckTarget()
    {
        if (characterList.Count > 0)
        {
            for (int i = 0; i < characterList.Count; i++)
            {
                target = characterList[i];
                min = Vector3.Distance(TF.position, target.TF.position);
                for (int j = i + 1; j < characterList.Count; j++)
                {
                    
                    if (min > Vector3.Distance(TF.position, characterList[j].TF.position))
                    {
                        min = Vector3.Distance(TF.position, characterList[j].TF.position);
                        target = characterList[j];
                        SetTarget(target);
                    }
                }
            }
        }
    }
    //protected void CheckTarget()
    //{
    //    if(characterList.Count > 0)
    //    {
    //        for (int i = 0; i < characterList.Count; i++)
    //        {
    //            min = Vector3.Distance(TF.position, characterList[i].TF.position);
    //            for (int j = i + 1; j < characterList.Count; j++)
    //            {
    //                if (min > Vector3.Distance(TF.position, characterList[j].TF.position))
    //                {
    //                    min = Vector3.Distance(TF.position, characterList[j].TF.position);
    //                    SetTarget(characterList[j]);
    //                }
    //            }
    //        }
    //    }       
    //}

    public void OnHit(float damage)
    {
        if(!isDeath)
        {
            hp -= damage;
        }
    }   
}

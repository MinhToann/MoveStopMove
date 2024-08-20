using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BotModel : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Transform handHolder;
    //WeaponBase currentWeapon;
    public void OnInit()
    {
        //WeaponManager.Instance.ChangeWeapon(currentWeapon,WeaponType.Axe, handHolder);
    }
    public Animator GetAnimator()
    {
        return animator;
    }
}

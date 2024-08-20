using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public Transform leftHand { get; private set; }
    [field: SerializeField] public Transform Head { get; private set; }
    [field: SerializeField] public Transform Legs { get; private set; }

    [SerializeField] GameObject imgWeapon;

    public void OnInit()
    {
        GameObject weapon = Instantiate(imgWeapon, leftHand);
        weapon.transform.position = leftHand.position;
        weapon.transform.rotation = leftHand.rotation;
    }

    public void SetOverrideAnimator(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
    public void SetAnimator(Animator animator)
    {
        this.animator = animator;
    }    
    public Animator GetAnimator()
    {
        return animator;
    }
}

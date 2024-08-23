using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BotModel : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Transform handHolder;

    public void SetOverrideAnimator(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
    public Animator GetAnimator()
    {
        return animator;
    }
}

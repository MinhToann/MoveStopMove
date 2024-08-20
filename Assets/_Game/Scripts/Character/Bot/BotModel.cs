using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BotModel : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Transform handHolder;

    public Animator GetAnimator()
    {
        return animator;
    }
}

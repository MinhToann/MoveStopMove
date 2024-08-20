using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraState : MonoBehaviour
{
    string currentAnim;
    Animator characterAnim;
    private void Awake()
    {
        characterAnim = GetComponent<Animator>();
    }
    public void ChangeAnim(string newAnim)
    {
        if (currentAnim != newAnim)
        {
            characterAnim.ResetTrigger(currentAnim);
            currentAnim = newAnim;
            characterAnim.SetTrigger(currentAnim);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Camera : MonoBehaviour
{

    private float lerpSpeed = 5f;
    private Transform tf;
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
    private void LateUpdate()
    { 
        if(LevelManager.Instance.getPlayer != null)
        transform.position = Vector3.Lerp(TF.position, LevelManager.Instance.getPlayer.TF.position + new Vector3(0, 0, -10f), lerpSpeed * Time.deltaTime);
    } 
}

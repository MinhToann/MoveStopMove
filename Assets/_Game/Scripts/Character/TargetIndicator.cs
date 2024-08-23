using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TargetIndicator : MonoBehaviour
{
    private Camera mainCam;
    private CinemachineVirtualCamera virtualCam;
    private Camera cam;
    [field: SerializeField] public Transform target { get; private set; }
    private float offset;
    [SerializeField] GameObject objTarget;

    public void OnInit(Transform target, Camera mainCam, float indicatorOffset)
    {
        this.target = target;
        this.mainCam = mainCam;
        this.offset = indicatorOffset;
    }
    public void UpdateTransformTarget()
    {
        if(target != null)
        {
            
        }
    }
}

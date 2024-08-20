using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //[SerializeField] List<Bot> listBots = new List<Bot>();
    [SerializeField] Transform xPos;
    [SerializeField] Transform zPos;
    [SerializeField] Transform startPos;
    float xRandomPos;
    float zRandomPos;

    public Vector3 GetStartPosition()
    {
        return startPos.position;
    }
    public Vector3 GetRandomPosition()
    {
        xRandomPos = Random.Range(-xPos.position.x, xPos.position.x);
        zRandomPos = Random.Range(-zPos.position.z, zPos.position.z);
        return new Vector3(xRandomPos, 0.5f, zRandomPos);

    }

}

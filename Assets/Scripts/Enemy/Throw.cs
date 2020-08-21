using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform startPoint;
    public GameObject stonePrefab;
    public void throwStone()
    {
        var myNewStone=Instantiate(stonePrefab, startPoint.position, startPoint.rotation);
        myNewStone.transform.parent = gameObject.transform;
    }

    void Update()
    {
        
    }
}

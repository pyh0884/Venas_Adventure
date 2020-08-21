using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamiBarai : MonoBehaviour
{
    public Transform startPoint;
    public GameObject YamiBaraiPrefab;

    public void throwYamiBarai()
    {
        var myNewYami=Instantiate(YamiBaraiPrefab, startPoint.position, startPoint.rotation);
        myNewYami.transform.parent = gameObject.transform;
    }

    void Update()
    {
        
    }
}

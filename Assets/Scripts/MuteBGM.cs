using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBGM : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.Find("AudioManager"));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SavedData
{
    public int hp;
    public float volume;

    public SavedData(HealthBarControl health)
    {
        hp = health.Hp;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyHitBox")
        {
            GameObject hit = col.gameObject;
            HealthPoint hp = col.GetComponent<HealthPoint>();
            hp.Damage(35 + (int)Random.Range(0, 10));
        }
        if (col.name == "Stone(Clone)" || col.name == "YamiBarai(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}

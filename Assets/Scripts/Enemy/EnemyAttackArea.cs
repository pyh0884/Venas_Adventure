using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerHitBox")
        {
            GameObject hit = col.gameObject;
            HealthBarControl hp = col.GetComponent<HealthBarControl>();
            hp.Damage(1);
        }
    }
}

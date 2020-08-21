using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="EnemyHitBox")
        {
            GameObject hit = col.gameObject;
            //if (hit.name != "BossHitBox")
            //{
                //击退怪物
            //}
            HealthPoint hp = col.GetComponent<HealthPoint>();
            //int damageCount = 20 + (int)Random.Range(-3, 3);
            //DamageTextControler.CreatDamageText(damageCount.ToString(), transform);
            hp.Damage(20 + (int)Random.Range(-7, 7));
        }
        //if (col.name == "Stone(Clone)"||col.name== "YamiBarai(Clone)")
        //{
        //    Destroy(col.gameObject);
        //}
    }
}

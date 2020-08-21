using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public GameObject mainObject;
    //private ParticleSystem ps;
    //void Awake()
    //{
    //    ps = GetComponent<ParticleSystem>();
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerHitBox")
        {
            GameObject hit = col.gameObject;
            HealthBarControl hp = col.GetComponent<HealthBarControl>();
            hp.Damage(2);
        }
        else if (col.tag == "Environment")
        {
            //ps.Play();
            mainObject.GetComponent<Animator>().SetTrigger("HitPlayer");
        }
    }

    void Update()
    {
        
    }
}

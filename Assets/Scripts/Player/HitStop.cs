using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    Animator anim;
    Animator playerAnim;
    public GameObject weapon;
    private float StopTime;
    public float StopFrames;
    void Start()
    {
        anim = weapon.GetComponent<Animator>();
        playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        StopTime = 0;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyHitBox") 
        {
            StopTime = 0;
            anim.speed = 0;
            playerAnim.speed = 0;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().controllable = false;
          }
    }

        void Update()
    {
        StopTime += Time.deltaTime;
        if(StopTime>=StopFrames)
        {
            anim.speed = 1;
            playerAnim.speed = 1;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().controllable = true;
        }
    }
}

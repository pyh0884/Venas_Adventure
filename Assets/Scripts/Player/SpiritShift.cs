using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritShift : MonoBehaviour
{
    public Animator anim;
    public bool record=false;
    public float EnterTime = 0f;
    public bool canSpirit = false;
    bool SpiritKey
    {
        get
        {
            return Input.GetMouseButtonDown(1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyAttack")
        {
            //Debug.Log("撞到" + col.name + "准备进入Spirit模式");

            if (canSpirit)
            {
                //Debug.Log("进入！");
                anim.SetTrigger("SpiritShift");
            }
        }
    }
    void Awake()
    {
        canSpirit = SpiritKey;
    }

    void FixedUpdate ()
    {

        if (SpiritKey)
        {
            //Debug.Log("按了哦");
            canSpirit = true;
            record = true;
        }
        if (record)
        {
            EnterTime += Time.deltaTime;
        }
        if (EnterTime >0.4f)//0.4f
        {
            EnterTime = 0f;
            canSpirit = false;
            record = false;
        }

    }
}

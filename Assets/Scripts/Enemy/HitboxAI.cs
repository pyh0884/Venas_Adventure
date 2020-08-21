using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class HitboxAI : MonoBehaviour
{
    
    public GameObject mainChara;
    public ParticleSystem bloodEFX = null;
    public Animator PlayerAnimator;
    [Header("是否为敌方单位")]
    public bool isEnemy;
    
    public void playBloodEFX()
    {
        bloodEFX.Play();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        switch (isEnemy)
        {
            case true:
                if (col.tag == "PlayerAttack")
                {
                    //Debug.Log("打到敌人了");
                    bloodEFX.transform.position = new Vector3(bloodEFX.transform.position.x, mainChara.transform.position.y, bloodEFX.transform.position.z);
                    playBloodEFX();
                    PlayerAnimator.SetTrigger("Hit");
                    col.enabled = false;
                }
                else if (col.tag == "PlayerHitBox")
                {
                    GameObject hit = col.gameObject;
                    HealthBarControl hp = col.GetComponent<HealthBarControl>();
                    hp.Damage(1);   
                }
                break;

            case false:
                if (col.tag == "EnemyAttack")
                {
                    //mainChara.GetComponent<PlayerMovement>().controllable = false;
                    mainChara.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 22), ForceMode2D.Impulse);

                    //Invoke("BackControl", 0.5f);
                    //Debug.Log("我被击中了！");
                    //播放受击动画
                    PlayerAnimator.SetTrigger("Hit");
                }
                break;
        }
    }
    void BackControl() 
    {
        mainChara.GetComponent<PlayerMovement>().controllable = true;
     
    }
    void Start()
    {
        //PlayerAnimator = mainChara.GetComponent<Animator>();
    }

    void FixedUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{
    private GameObject player;
    public GameObject EFX;
    private ParticleSystem ps;
    public float xAxis;
    private bool checkPosition = true;
    void Awake()
    {
        ps = EFX.GetComponent<ParticleSystem>();
        xAxis = GameObject.FindGameObjectWithTag("Enemy").transform.position.x;
        player =GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator DoNothing()
    {
        yield return new WaitForSeconds(1.5f);
        if (checkPosition == true)
        {
            transform.LookAt(player.transform);
            checkPosition = false;
        }     
        transform.Translate(Vector3.forward*Time.deltaTime*60);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //player被击中后会播放Hit动画，并被击飞
        if (col.tag == "PlayerHitBox")
        {
            FindObjectOfType<AudioManager>().Play("StoneHit");
            Destroy(EFX, 2);
            ps.transform.parent = null;
            //Debug.Log("我被砸到了！");
            //PlayerMovement pm = player.GetComponent<PlayerMovement>();
            //pm.Dazed(xAxis);
            HealthBarControl hp = col.GetComponent<HealthBarControl>();
            hp.Damage(1);
            DestroyStone();
        }
        else if (col.tag == "Environment")
        {
            Destroy(EFX, 2);
            ps.transform.parent = null;
            DestroyStone();
        }
        Destroy(gameObject,5);
    }

    void DestroyStone()
    {
        GetComponent<Animator>().SetTrigger("Hit");
    }

    void StoneDestroy()
    {
        Destroy(gameObject);
    }
    void playEFX()
    {
        ps.Play();
    }
    void FixedUpdate()
    {
            StartCoroutine(DoNothing());
    }
}

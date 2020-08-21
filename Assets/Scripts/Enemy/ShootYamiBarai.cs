using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 攻击的行为
/// </summary>
//攻击到tag为environment的collider后自动销毁
public class ShootYamiBarai : MonoBehaviour
{
    private ParticleSystem ps;
    public GameObject EFX;

    void Awake()
    {
        ps = EFX.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //player被击中后会播放Hit动画
        if (col.tag == "PlayerHitBox")
        {
            Destroy(EFX, 2);
            ps.transform.parent = null;
            //Debug.Log("我被砸到了！");
            GameObject hit = col.gameObject;
            HealthBarControl hp = col.GetComponent<HealthBarControl>();
            hp.Damage(1);
            DestroyYamiBarai();
        }
        else if (col.tag == "Environment")
        {
            Destroy(EFX, 2);
            ps.transform.parent = null;
            DestroyYamiBarai();
        }
        Destroy(gameObject, 5);
    }

    void DestroyYamiBarai()
    {
        GetComponent<Animator>().SetTrigger("Hit");
    }

    void YamiBaraiDestroy()
    {
        Destroy(gameObject);
    }
    void playEFX()
    {
        ps.Play();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 30);
    }
}

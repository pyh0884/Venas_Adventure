using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneThrowerAI : MonoBehaviour
{
    [Header("who is the player")]
    public GameObject Player;
    public Rigidbody2D EnemyRigidbody2D;
    public Text hpText;
    public Slider hpSlider;
    public Animator anim;
    public int hp = 100;
    [Range(0, 100)]
    public int hpMax = 100;
    [Header("distance from enemy to player")]
    public float DistanceToMe;

    void throwInRange()
    {
        if (DistanceToMe < 50)
        {
            anim.SetBool("Throw", true);
        }
        else
        {
            anim.SetBool("Throw", false);
        }
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        hp = hpMax;
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        throwInRange();
        if (Player != null)
            DistanceToMe = Vector2.Distance(Player.transform.position, EnemyRigidbody2D.transform.position);
    }
}

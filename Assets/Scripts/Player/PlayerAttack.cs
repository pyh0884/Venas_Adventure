using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 挥剑出招的行为
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    public Collider2D AtkCollider;
    Animator weaponAnimator;
    public GameObject main;
    public Animator EFXAnimator;

    public void PlaySlashEFX()
    {
        //if (weaponAnimator.name== "NormalWeapon")
        //FindObjectOfType<AudioManager>().Play("Slash1");
        //else      
        //FindObjectOfType<AudioManager>().Play("Slash2");    Need find better Slash Audio

        FindObjectOfType<AudioManager>().Play("Slash1");
        EFXAnimator.SetTrigger("Attack");
    }

    public void AttackStart()
    {

        AtkCollider.enabled = true;
    }

    public void AttackStop()
    {
        AtkCollider.enabled = false;
    }


    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && main.GetComponent<PlayerMovement>().controllable==true)
        {
            //Debug.Log("clicked");
            main.GetComponent<Animator>().SetTrigger("Attack");
            weaponAnimator.SetTrigger("Attack");
        }
    }
}

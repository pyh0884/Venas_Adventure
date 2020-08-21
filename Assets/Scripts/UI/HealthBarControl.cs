using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    private int MaxHeartAmount = 5; //for later use if the player can increase the HP capacity
    public int Heart = 5;
    public int Hp = 10;
    public int HpMax = 10;
    public Image[] HeartImages;
    public Sprite[] HeartSprites;
    public GameObject mainObject;
    private Animator anim;

    void Awake()
    {
        Hp = Heart * 2;
        Heart = (Hp + 1) / 2;
        HpMax = MaxHeartAmount * 2;
        currentHealth();
        anim = mainObject.GetComponent<Animator>();
    }

    public void saveHp()
    {
        SaveData.saveHp(this);
    }

    public void loadHp()
    {
        SavedData data= SaveData.loadHp();
        Hp = data.hp;
    }

    public void Damage(int damageCount)
    {
        FindObjectOfType<AudioManager>().Play("Player_Hit");
        anim.SetTrigger("Hit");
        Hp -= damageCount;
        Hp = Mathf.Clamp(Hp, 0, HpMax);
        currentHealth();

    }
    void currentHealth()
    {
        Heart = (Hp + 1) / 2;
        if (Hp <= 0)
        {
            DieStart(mainObject);
        }
        for (int j = 0; j < MaxHeartAmount; j++)
        {
            if (Heart <= j)
            {
                HeartImages[j].enabled = false;
            }
            else
            {
                HeartImages[j].enabled = true;
            }
        }

        int i = 0;
        foreach (Image image in HeartImages)
        {
            i++;
            if (Hp >= i * 2)
            {
                image.sprite = HeartSprites[1];
            }
            else
            {
                image.sprite = HeartSprites[0];
            }
        }
        
    }

    public void DieStart(GameObject obj)
    {
        mainObject.GetComponent<PlayerMovement>().controllable = false;
        anim.SetTrigger("Die");

    }

    public void Dying()
    {

    }

    public void DieEnd()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextControler : MonoBehaviour
{
    private static GameObject canv;
    private static DamageText damageText;
    public static void CreatDamageText(string str, Transform position)
    {
        DamageText exp = Instantiate(damageText);
        exp.transform.SetParent(canv.transform,false);
        exp.SetText(str);
    }

    public static void Initialize()
    {
        canv = GameObject.Find("BossCanvas");
        if (!damageText)
        {
            damageText = Resources.Load<DamageText>("DamageTextParent");
        }
    }
}

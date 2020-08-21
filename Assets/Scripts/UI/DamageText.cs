﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DamageText : MonoBehaviour
{
    public Animator anim;
    private TextMeshProUGUI damageText;
    void Awake()
    {
        AnimatorClipInfo[] clipsInfo = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, 1.5f);
        damageText = anim.GetComponent<TextMeshProUGUI>();
    }
    public void SetText(string str)
    {
        if (str != null)
        {
            damageText.text = str;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float HP;
    public Image hPBar;
    public Sprite[] sprite;

    void Start()
    {
        HP = 1.0f;
    }

    public void TakeDamage(float amount , float addhealth)
    {
        HP -= amount;
        HP += addhealth;
        if (HP <= 0.5f)
        {
            if (HP <= 0.25f) hPBar.sprite = sprite[2];
            else hPBar.sprite = sprite[1];
        }
        else hPBar.sprite = sprite[0];

        if (HP <= 0)
        {
            HP = 0;
        }

        hPBar.GetComponent<Image>().fillAmount = HP;
    }
}

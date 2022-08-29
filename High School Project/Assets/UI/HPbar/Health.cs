using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float playerHP;
    public Image hPBar;
    public void TakeDamage(float amount)
    {
        playerHP -= amount;
        hPBar.GetComponent<Image>().fillAmount -= amount;

        if(playerHP <= 0)
        {
            playerHP = 0;
            Debug.Log("You Died!");
        }
    }
}

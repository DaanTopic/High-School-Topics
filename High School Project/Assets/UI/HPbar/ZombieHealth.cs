using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    public float HP;

    public void TakeDamage(float amount)
    {
        HP -= amount;
    }
}

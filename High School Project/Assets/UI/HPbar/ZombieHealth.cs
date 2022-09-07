using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchDamage : MonoBehaviour
{
    private Health health;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            health.TakeDamage(0.1f);
        }
    }
}
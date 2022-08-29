using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject hit = other.gameObject;
            Health health = hit.GetComponent<Health>();
            health.TakeDamage(0.1f);
        }    
    }
}

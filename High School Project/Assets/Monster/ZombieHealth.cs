using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    private float hp;
    void Start()
    {
        hp = 1.0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "pfBulletProjectile(Clone)")
        {
            hp -= 0.1f;
            Debug.Log(hp);
        }
        if(hp <= 0)
        {
            hp = 0f;
            Destroy(gameObject);
        }
    }
}
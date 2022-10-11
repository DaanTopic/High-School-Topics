using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{

    private float hp;
    float timer = 0;
    float duration = 0f;

    void Start()
    {
        hp = 1.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnCollisionStay(Collision collision)
    {
        if (timer >= duration && collision.gameObject.tag == "BarbedWire")
        {
            duration = 1f;
            hp -= 0.5f;
            timer = 0;
            Debug.Log("Enemy touched");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "pfBulletProjectile(Clone)")
        {
            hp -= 0.1f;
        }
        if (hp <= 0)
        {
            hp = 0f;
            gameObject.tag = "Untagged";
            Destroy(gameObject);
        }
    }
}

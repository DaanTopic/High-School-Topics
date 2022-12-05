using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    private gamerules gamerules;
    public float hp = 1.0f;
    float timer = 0f;
    float duration = 0f;

    void Start()
    {
        gamerules = GameObject.Find("GameRules").GetComponent<gamerules>();
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
            timer = 0f;
            Debug.Log("Enemy touched");
        }
        if (hp <= 0)
        {
            ZombiePooler zombiePooler = ZombiePooler.Instance;

            ++gamerules.killamount;
            hp = 1.0f;
            zombiePooler.ZombieDead("Zombie", this.gameObject);
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
            ZombiePooler zombiePooler = ZombiePooler.Instance;

            ++gamerules.killamount;
            hp = 1.0f;
            zombiePooler.ZombieDead("Zombie", this.gameObject);
        }
    }
}
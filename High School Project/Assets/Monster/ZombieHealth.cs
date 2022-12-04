using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    private gamerules gamerules;
    private float hp;
    float timer = 0;
    float duration = 0f;

    void Start()
    {
        gamerules = GameObject.Find("GameRules").GetComponent<gamerules>();
        hp = 1.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (hp <= 0)
        {
            ZombiePooler zombiePooler = ZombiePooler.Instance;
            
            ++gamerules.killamount;
            zombiePooler.ZombieDead("Zombie", this.gameObject);
            GameObject.Find("ZombiePool").GetComponent<ZombieSpawner>().zombieAmount -= 1;
        }
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
    }
}
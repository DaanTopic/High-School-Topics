using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XANFSM.zombie
{
    public class ZombieHealth : MonoBehaviour
    {
        private gamerules gamerules;
        public float hp = 1.0f;
        public Transform deadbody;
        float timer = 0f;
        float duration = 0f;

        void Start()
        {
            gamerules = GameObject.Find("GameRules").GetComponent<gamerules>();
        }

        void Update()
        {
            timer += Time.deltaTime;
            Vector3 vector3 = transform.position;
            if (hp <= 0)
            {
                

                ZombiePooler zombiePooler = ZombiePooler.Instance;
                ++gamerules.killamount;
                hp = 1.0f;
                var tag = this.gameObject.tag;
                zombiePooler.ZombieDead(tag, this.gameObject);

                
            }
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
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "pfBulletProjectile(Clone)")
            {
                hp -= 0.1f;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if ((!GameObject.FindWithTag("Player").GetComponent<PlayerAction>().isAttack) && other.gameObject.tag == "Leg")
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerAction>().isAttack = true;
                hp -= 1f;
            }
        }
    }
}
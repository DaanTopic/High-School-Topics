using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XANFSM
{
    public class AttackTrigger : MonoBehaviour
    {
        private bool isAttack = false;
        public void StartAttack()
        {
            isAttack = false;
            GetComponent<Collider>().enabled = true;
        }
        public void EndAttack()
        {
            GetComponent<Collider>().enabled = false;
        }
        public void OnTriggerEnter(Collider other)
        {
            if (!isAttack && other.gameObject.tag == "Player")
            {
                isAttack = true;
                other.gameObject.GetComponent<Health>().TakeDamage(0.1f, 0f);
            }
        }
    }
}
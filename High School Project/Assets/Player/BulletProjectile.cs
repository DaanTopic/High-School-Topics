using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour 
{

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<BulletTarget>() != null) {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        } else {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
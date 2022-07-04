using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    private Transform target;
    public float MoveSpeed = 3.5f;
    private NavMeshAgent nav;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = MoveSpeed;
        if (nav == null)
        {
            nav = gameObject.AddComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        nav.SetDestination(target.transform.position);
    }
    void FixedUpdate() {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}

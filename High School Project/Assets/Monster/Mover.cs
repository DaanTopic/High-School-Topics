using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mover : MonoBehaviour
{
    NavMeshAgent navAgent;
    private void Awake() {
        navAgent = GetComponent<NavMeshAgent>();
    }
    public void MoveTo(Vector3 destination, float speed){
        navAgent.isStopped = false;
        navAgent.speed = 1f * Mathf.Clamp01(speed);
        navAgent.destination = destination;
    }
}

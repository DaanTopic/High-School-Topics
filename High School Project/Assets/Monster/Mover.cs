using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [Tooltip("max speed")]
    [SerializeField] float maxSpeed = 6f;
    NavMeshAgent navmeshagent;
    private void Awake() {
        navmeshagent = GetComponent<NavMeshAgent>();
    }
//移動到目標
    public void MoveTo(Vector3 destination, float speed){
        navmeshagent.isStopped = false;
        navmeshagent.speed = speed * Mathf.Clamp01(speed);
        navmeshagent.destination = destination;
    }
//停止移動
    public void CancelMove(){
        navmeshagent.isStopped=true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ZombieState
{
    Idle, Death, Walk, Chase, Attack, Hurt
}
public class Zombie : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private ZombieState currentState;

    private void Update()
    {
        switch (currentState)
        {
            case ZombieState.Idle:
                animator.SetBool("walk", false);
                break;
        }
    }
}

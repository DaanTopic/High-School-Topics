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
    private ZombieState currentState;

    private void Update()
    {
        switch (currentState)
        {
            case ZombieState.Idle:
                return;
        }
    }
}

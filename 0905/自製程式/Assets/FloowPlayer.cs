using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloowPlayer : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    private void Update() {
        transform.position=Player.position+offset;
    }
}

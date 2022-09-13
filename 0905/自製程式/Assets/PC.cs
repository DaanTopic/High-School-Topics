using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 10.0f;
    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D))
            {
                Movement();
            }
        }
        else
        {
            moveDirection = Vector3.zero;
            moveDirection.y = gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
    private void Movement()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        controller.Move(moveDirection * Time.deltaTime);
    }
}

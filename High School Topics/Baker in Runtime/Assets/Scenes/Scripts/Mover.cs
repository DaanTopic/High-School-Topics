using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        gameObject.transform.Translate(new Vector3(x,0,y) * speed * Time.deltaTime);
    }
}

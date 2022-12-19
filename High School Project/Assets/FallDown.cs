using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{

    private float setTime;
    private void Start()
    {
        GetComponent<Animator>().enabled = true;
        setTime = Time.time + 0.1f;
        Destroy(gameObject, 7.0f);
    }

    private void Update()
    {
        if (setTime < Time.time)
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}
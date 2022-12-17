using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{

    float settime;
    void Start()
    {
        GetComponent<Animator>().enabled = true;
        settime = Time.time;
    }

    void Update()
    {
        if (settime + 0.1f < Time.time)
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}

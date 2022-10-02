using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer_f;
    public int timer_i;
    void Update()
    {
        timer_f = Time.time;
        timer_i = Mathf.FloorToInt(timer_f);
    }
}

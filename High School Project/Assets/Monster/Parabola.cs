using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    public int Duration = 5;
    private Transform tStart, tEnd;
    private float _duration;

    void Start()
    {
        tStart = this.gameObject.transform;
        tEnd = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        var pStart = tStart.position;
        var pEnd = tEnd.position;
        var p = (pStart + pEnd) / 2 + (Vector3.up * 1);

        var t = _duration / Duration;
        this.gameObject.transform.position =
            Mathf.Pow(1 - t, 2) * pStart +
            2 * t * (1 - t) * p +
            Mathf.Pow(t, 2) * pEnd;

        _duration += Time.deltaTime;

        if(_duration > 5) Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Health>().TakeDamage(0.1f, 0f);
                Destroy(this.gameObject);
            }
        }
}

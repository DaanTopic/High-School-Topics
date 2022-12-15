using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    public float Duration;
    private float _duration;
    private Vector3 p, pStart, pEnd;

    void Start()
    {
        pStart = this.gameObject.transform.position;
        pEnd = GameObject.FindWithTag("Player").transform.position;
        p = (pStart + pEnd) / 2 + (Vector3.up * 2.25f);
    }
    private void Update()
    {
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthRegenerate : MonoBehaviour
{
    float minDist = 2;
    float reChargeTime, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        reChargeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        GameObject player = GameObject.FindWithTag("Player");
        GameObject tag = GameObject.FindWithTag("rule");
        HealthRegenDist HealthRegenDist = tag.GetComponent<HealthRegenDist>();
        Vector3 dist = HealthRegenDist.dist;
        Vector3 Healthpack = transform.position;
        float distance = Vector3.Distance(dist, Healthpack);
        if (distance < minDist)
        {
            if (currentTime > reChargeTime + 0.6f)
            {
                reChargeTime = currentTime;
                // 補血
                player.gameObject.GetComponent<Health>().TakeDamage(0.0f, 0.15f);
            }
        }
    }
}

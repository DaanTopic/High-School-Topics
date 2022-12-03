using System.Collections;
using System.Collections.Generic;
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
        Vector3 playerPosi = GameObject.FindWithTag("Player").transform.position; //用標籤找玩家位置
        Vector3 HealthRegen = GameObject.FindWithTag("Healthregenerate").transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(playerPosi, HealthRegen);
        if (dist < minDist)
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

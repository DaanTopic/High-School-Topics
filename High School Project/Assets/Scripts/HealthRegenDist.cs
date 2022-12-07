using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthRegenDist : MonoBehaviour
{
    public Vector3 dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Distance();
    }

    public Vector3 Distance()
    {
        Vector3 playerPosi = GameObject.FindWithTag("Player").transform.position; //用標籤找玩家位置
        //Vector3 HealthRegen = GameObject.FindWithTag("Healthregenerate").transform.position;
        //return Vector3.Distance(playerPosi, HealthRegen);
        return playerPosi;
    }
}

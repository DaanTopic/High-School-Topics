using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    float minDist = 3;
    float reChargeTime, currentTime;
    int i = 0;
    [SerializeField] public TextMeshProUGUI Dialogue;
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
        Vector3 Bottle = GameObject.FindWithTag("Bottle").transform.position;
        MeshRenderer BottleRender = GameObject.FindWithTag("Bottle").GetComponent<MeshRenderer>();
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(playerPosi, Bottle);
        if (dist < minDist)
        {
            if (currentTime > reChargeTime + 3.5f)
            {
                if (BottleRender.enabled == true)
                {
                    BottleRender.enabled = false;
                }
            }
        }
    }
}

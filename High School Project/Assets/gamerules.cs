using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class gamerules : MonoBehaviour
{
    double GameCollapseTime;
    [SerializeField] public TextMeshProUGUI TimeCount;
    // Start is called before the first frame update
    void Start()
    {
        TimeCount.text = GameCollapseTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GameCollapseTime = Time.time;
        GameCollapseTime = Math.Round(GameCollapseTime, 2, MidpointRounding.AwayFromZero);
        TimeCount.text = GameCollapseTime.ToString();
    }
}

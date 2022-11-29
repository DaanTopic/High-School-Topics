using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class gamerules : MonoBehaviour
{
    double GameCollapseTime;
    int schedule = 0;
    public int killamount = 0;
    float settime;
    [SerializeField] public TextMeshProUGUI TextMission;
    // Start is called before the first frame update
    void Start()
    {
        TextMission.text = "任務列";
        settime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (settime + 3f < Time.time && schedule == 0)
        {
            TextMission.text = "按下WASD來操控人物";
            schedule = 1;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) && schedule == 1);
        {
            schedule = Mission(schedule);
        }
        if (Input.GetKey(KeyCode.Mouse1) && schedule == 2)
        {
            schedule = Mission(schedule);
        }
        if (Input.GetKeyDown(KeyCode.I) && schedule == 3)
        {
            schedule = Mission(schedule);
        }
        if (Input.GetKeyDown(KeyCode.B) && schedule == 4)
        {
            schedule = Mission(schedule);
        }

    }

    public int Mission(int number)
    {

        if (number == 1)
        {
            TextMission.text = "按下滑鼠右鍵來瞄準";
            return 2;
        }
        if (number == 2)
        {
            TextMission.text = "按下I來打開背包";
            return 3;
        }
        if (number == 3)
        {
            TextMission.text = "按下B來進行建築模式";
            return 4;
        }
        if (number == 4)
        {
            TextMission.text = "擊殺一隻殭屍";
            return 5;
        }
        if (number == 5)
        {
            TextMission.text = "往前尋找女孩對話";
            return 6;
        }
        return schedule;
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class gamerules : MonoBehaviour
{
    double GameCollapseTime;
    public int schedule = 0;
    public int killamount = 0;
    public bool keyget = false, Events = false;
    float settime;
    [SerializeField] public TextMeshProUGUI TextMission;
    [SerializeField] public TextMeshProUGUI Kill;
    // Start is called before the first frame update
    void Start()
    {
        TextMission.text = "任務列";
        settime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (settime + 1f < Time.time && schedule == 0)
        {
            TextMission.text = "按下WASD來操控人物";
            schedule = 1;
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && schedule == 1)
        {
            schedule = Mission(schedule);
        }
        if (Input.GetKey(KeyCode.Mouse1) && schedule == 2)
        {
            schedule = Mission(schedule);
        }
        if (Input.GetKey(KeyCode.I) && schedule == 3)
        {
            schedule = Mission(schedule);
        }
        
        if (Input.GetKey(KeyCode.B) && schedule == 4)
        {
            schedule = Mission(schedule);
        }
        if (killamount>=1 && schedule == 5)
        {
            schedule = Mission(schedule);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
        }
        if (killamount>10 && schedule == 9)
        {
            schedule = Mission(schedule);
        }
        Kill.text = ""+killamount;
        if (keyget == true && schedule == 12)
        {
            schedule = Mission(schedule);
        }
        if(schedule==15 && (Time.time-settime)>10.0f &&(Time.time-settime)<99.0f ){
            Events=true;
        }
        if(schedule==15 && (Time.time-settime)>100.0f){
            Events=false;
            schedule=Mission(schedule);
        }
        Debug.Log(Time.time-settime);
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
        if (number == 7)
        {
            TextMission.text = "";
            return 8;
        }
        if (number == 8)
        {
            TextMission.text = "清理前方殭屍";
            return 9;
        }
        if (number == 9)
        {
            TextMission.text = "去尋找村長";
            return 10;
        }
        if (number == 10)
        {
            TextMission.text = "";
            return 11;
        }
        if (number == 11)
        {
            TextMission.text = "尋找素材";
            return 12;
        }
        if (number == 12)
        {
            TextMission.text = "回去與村長對話";
            return 13;
        }
        if (number == 13)
        {
            TextMission.text = " ";
            settime = Time.time;
            return 14;
        }
        if (number == 14)
        {
            TextMission.text = "防守村長家";
            settime = Time.time;
            return 15;
        }
        return schedule;
    }
}
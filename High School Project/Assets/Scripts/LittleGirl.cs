using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LittleGirl : MonoBehaviour
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
        Vector3 LittleGirl = GameObject.FindWithTag("LittleGirl").transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(playerPosi, LittleGirl);
        if (dist < minDist)
        {
            if (currentTime > reChargeTime + 3.5f)
            {
                reChargeTime = currentTime;
                
                
                if(i == 0)
                {
                    Dialogue.text = ("Hi，看來你的車子拋錨了");
                }
                if (i == 1)
                {
                    Dialogue.text = ("如你所見，這裡遭受了疆屍攻擊");
                }
                if (i == 2)
                {
                    Dialogue.text = ("你應該是要前往避難所對吧? 跟我們一樣");
                }
                if (i == 3)
                {
                    Dialogue.text = ("村長載著我們的公車拋錨了，他似乎在前方尋找出去的方法");
                }
                if (i == 4)
                {
                    Dialogue.text = ("如果你願意的話，可以幫我清理前方的疆屍嗎?");
                }
                if (i == 5)
                {
                    Dialogue.text = ("");
                }
                i++;
            }
        }
    }
}

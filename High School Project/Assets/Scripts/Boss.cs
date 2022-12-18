using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    float minDist = 3;
    float reChargeTime, currentTime;
    public int i = 0;
    bool chake=false;
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
        Vector3 Boss = GameObject.FindWithTag("Boss").transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(playerPosi, Boss);
        GameObject x = GameObject.FindWithTag("rule");
        gamerules gamerules = GameObject.FindWithTag("rule").GetComponent<gamerules>();
        if (dist < minDist && x.GetComponent<gamerules>().schedule>=10){
            chake=true;
        }

        if (chake==true)
        {


            if (currentTime > reChargeTime + 3.5f)
            {
                reChargeTime = currentTime;


                if (i == 0)
                {
                    x.GetComponent<gamerules>().schedule=x.GetComponent<gamerules>().Mission(10);
                    Dialogue.text = ("Hi,真高興能夠在這樣的狀況下遇到其他倖存者");
                    i++;
                }
                else if (i == 1)
                {
                    Dialogue.text = ("我們的村子被殭屍侵襲,我們在逃離的過程中困在這裡");
                    i++;
                }
                else if (i == 2)
                {
                    Dialogue.text = ("但很不幸的是,我在逃離的過程中不小心被感染了");
                    i++;
                }
                else if (i == 3)
                {
                    Dialogue.text = ("如果你願意的話,是否能夠幫我尋找製作解藥的素材");
                    i++;
                }
                else if (i == 4)
                {
                    Dialogue.text = ("素材有1個,在接近道路末端的木頭小屋裡");
                    i++;
                }
                else if (i == 5)
                {
                    Dialogue.text = ("找到後把他使用掉,這樣我才能為逃脫做準備");
                    i++;
                }
                else if (i == 6)
                {
                    x.GetComponent<gamerules>().schedule = x.GetComponent<gamerules>().Mission(11);    //尋找鑰匙的最後一句對話位置
                    Dialogue.text = ("");
                    i++;
                }
                else if (gamerules.keyget && i == 7 && x.GetComponent<gamerules>().schedule ==12)
                {
                    x.GetComponent<gamerules>().schedule = x.GetComponent<gamerules>().Mission(12); 
                }
                else if (gamerules.keyget && i == 7 && dist < minDist)
                {
                    x.GetComponent<gamerules>().schedule = x.GetComponent<gamerules>().Mission(13); 
                    Dialogue.text = ("看來你找到解藥了!");
                    i++;
                }
                else if (gamerules.keyget && i == 8 && dist < minDist)
                {
                    Dialogue.text = ("接下來是最後一步!");
                    i++;
                }
                else if (gamerules.keyget && i == 9 && dist < minDist)
                {
                    Dialogue.text = ("你等我修好我的車鑰匙");
                    i++;
                }
                else if (gamerules.keyget && i == 10 && dist < minDist)
                {
                    Dialogue.text = ("這樣我們三個才能一起逃脫");
                    i++;
                }
                else if (gamerules.keyget && i == 11 && dist < minDist)
                {
                    Dialogue.text = ("但是修鑰匙的聲音會吸引殭屍");
                    i++; ; ;
                }
                else if (gamerules.keyget && i == 12 && dist < minDist)
                {
                    Dialogue.text = ("不論他們距離你多遠都會朝著你來!");
                    i++;
                }
                else if (gamerules.keyget && i == 13 && dist < minDist)
                {
                    Dialogue.text = ("在這期間,請幫忙防守這裡!");
                    i++;
                }
                else if (gamerules.keyget && i == 14)
                {
                    x.GetComponent<gamerules>().schedule = x.GetComponent<gamerules>().Mission(14);
                    Dialogue.text = ("");
                    i++;
                }
                else if (gamerules.BossPostEventDialogue && i == 15)
                {
                    x.GetComponent<gamerules>().schedule = x.GetComponent<gamerules>().Mission(16);
                    Dialogue.text = ("看來你把成功防守住了!");
                    i++;
                }
                else if (gamerules.BossPostEventDialogue && i == 16)
                {
                    Dialogue.text = ("幸虧有你的幫助,我把車鑰匙修好了");
                    i++;
                }
                else if (gamerules.BossPostEventDialogue && i == 17)
                {
                    Dialogue.text = ("");
                    i++;
                }
            }
        }
    }
}

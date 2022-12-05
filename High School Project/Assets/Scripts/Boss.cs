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
        Vector3 Boss = GameObject.FindWithTag("Boss").transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(playerPosi, Boss);

        gamerules gamerules = GameObject.FindWithTag("rule").GetComponent<gamerules>();

        if (dist < minDist)
        {


            if (currentTime > reChargeTime + 3.5f)
            {
                reChargeTime = currentTime;


                if (i == 0)
                {
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
                    Dialogue.text = ("素材有1個,四散在地圖各處");
                    i++;
                }
                else if (i == 5)
                {
                    Dialogue.text = ("找到後帶給我,這樣我才能為逃脫做準備");
                    i++;
                }
                else if (gamerules.keyget && i == 6)
                {

                    Dialogue.text = ("看來你找到解藥了!");
                    i++;
                }
                else if (gamerules.keyget && i == 7)
                {

                    Dialogue.text = ("");
                    i++;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    //public Color color = End.GetComponent<Image>.color;
    public Image end;
    public float TimeFPS, colorA=0f;
    // Start is called before the first frame update
    void Start()
    {
        
        TimeFPS=Time.time;
        end.rectTransform.position=new Vector3(2912f,538f,0f);
       // color.a = 0f;
        end.color = new Color(0 , 0 ,0 ,colorA);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(end.rectTransform.position);
        Debug.Log(colorA);
        GameObject end1 = GameObject.FindWithTag("rule");
        if(end1.GetComponent<gamerules>().End && (Time.time-TimeFPS)>=0.016f && colorA<=1f){
            end.rectTransform.position=new Vector3(957f,543f,0f);
            TimeFPS=Time.time;
            Debug.Log("--------------------------------------");
            end.color = new Color(0 , 0 ,0 ,colorA);
            if(colorA<1){
                colorA += 0.01f;
                end.color = new Color(0 , 0 ,0 ,colorA);
            }
        }
    }
}
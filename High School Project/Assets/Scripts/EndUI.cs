using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    //public Color color = End.GetComponent<Image>.color;
    public Image end;
    public TextMeshProUGUI dead;
    public float TimeFPS, colorA=0f;
    GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
        TimeFPS=Time.time;
        end.rectTransform.position=new Vector3(2912f,538f,0f);
       // color.a = 0f;
        end.color = new Color(0 , 0 ,0 ,colorA);
        gameObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float a = gameObject.GetComponent<Health>().HP;
       // Debug.Log(end.rectTransform.position);
       // Debug.Log(colorA);
        GameObject end1 = GameObject.FindWithTag("rule");
        //if(end1.GetComponent<gamerules>().End && (Time.time-TimeFPS)>=0.016f && colorA<=1f){
        //    dead.text = "Congratulations";
        //    end.rectTransform.position=new Vector3(957f,543f,0f);
        //    TimeFPS=Time.time;
        //    Debug.Log("--------------------------------------");
        //    end.color = new Color(0 , 0 ,0 ,colorA);
        //    if(colorA<1){
        //        colorA += 0.01f;
        //        end.color = new Color(0 , 0 ,0 ,colorA);
        //    }
        //    else
        //    {
        //        SceneManager.LoadScene(1);
        //    }
        //}
            if (a <= 0 && (Time.time - TimeFPS) >= 0.016f && colorA <= 1f)
            {
                dead.text = "You Dead";
                end.rectTransform.position = new Vector3(957f, 543f, 0f);
                TimeFPS = Time.time;
                Debug.Log("--------------------------------------");
                end.color = new Color(255, 255, 255, colorA);
                if (colorA < 1)
                {
                    colorA += 0.01f;
                    end.color = new Color(255, 255, 255, colorA);
                Debug.Log(colorA);
                }
            }
            if(colorA >= 1.0f)
            {
                 SceneManager.LoadScene(1);
                 Cursor.lockState = CursorLockMode.Confined;
             }
  


    }

 }
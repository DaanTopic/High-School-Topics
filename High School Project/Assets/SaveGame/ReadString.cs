using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadString : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public string[] TMP={};
    public string fileString;
    void Start()
    {
        GameObject bossi = GameObject.FindWithTag("Boss");
        GameObject x = GameObject.FindWithTag("rule");
        using (StreamWriter writer = new StreamWriter(Application.streamingAssetsPath+"Save.txt"))
        {
            // Write the string to the file
            writer.Write(1 +","+ 1 +","+ 1 +","+x.GetComponent<gamerules>().schedule+","+x.GetComponent<gamerules>().killamount+","+bossi.GetComponent<Boss>().i);
            
        }
        using (StreamReader reader = new StreamReader(Application.streamingAssetsPath+ "Save.txt"))
        {
            // Read the entire file and store the string in a variable
            fileString = reader.ReadToEnd();

        }
    }
    

    // Update is called once per frame
    void Update()
    {
        GameObject bossi = GameObject.FindWithTag("Boss");
        GameObject x = GameObject.FindWithTag("rule");
        TMP=fileString.Split(',');
        //Debug.Log("MISSION"+TMP[3]+TMP[4]);

        
        if(x.GetComponent<gamerules>().schedule==6 || x.GetComponent<gamerules>().schedule==10 || x.GetComponent<gamerules>().schedule==13 || x.GetComponent<gamerules>().schedule==16){
            Debug.Log("------------------------------------------------"+TMP[3]+TMP[4]);
            SaveMission();
            
        }
    }
    void SaveMission(){
        GameObject bossi = GameObject.FindWithTag("Boss");
        GameObject x = GameObject.FindWithTag("rule");
        using (StreamWriter writer = new StreamWriter(Application.streamingAssetsPath+"Save.txt"))
            {
                writer.Write(1 +","+ 1 +","+ 1 +","+x.GetComponent<gamerules>().schedule+","+x.GetComponent<gamerules>().killamount+","+bossi.GetComponent<Boss>().i);

            }
        Loading();
            
    }
    void Loading(){
        
        using (StreamReader reader = new StreamReader(Application.streamingAssetsPath+ "Save.txt"))
        {
            
            // Read the entire file and store the string in a variable
            fileString = reader.ReadToEnd();

        }
    }
}

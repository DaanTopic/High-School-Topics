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
        
        GameObject x = GameObject.FindWithTag("rule");
        using (StreamWriter writer = new StreamWriter(Application.streamingAssetsPath+"Save.txt"))
        {
            // Write the string to the file
            writer.Write("13516816,848498,34,"+x.GetComponent<gamerules>().schedule+","+x.GetComponent<gamerules>().killamount);
            
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
        GameObject x = GameObject.FindWithTag("rule");
        TMP=fileString.Split(',');
        Debug.Log("MISSION"+TMP[3]+TMP[4]);

        
        if(x.GetComponent<gamerules>().schedule>=1){
            SaveMission();
            Loading();
        }
    }
    void SaveMission(){
        GameObject x = GameObject.FindWithTag("rule");
        using (StreamWriter writer = new StreamWriter(Application.streamingAssetsPath+"Save.txt"))
            {
                writer.Write("1,1,0,"+x.GetComponent<gamerules>().schedule+","+x.GetComponent<gamerules>().killamount);
            
            }
            
    }
    void Loading(){
        
        using (StreamReader reader = new StreamReader(Application.streamingAssetsPath+ "Save.txt"))
        {
            
            // Read the entire file and store the string in a variable
            fileString = reader.ReadToEnd();

        }
    }
}

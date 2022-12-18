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
        // Vector3 playerPosi = GameObject.FindWithTag("Player").transform.position; 
        // GameObject bossi = GameObject.FindWithTag("Boss");
        // GameObject x = GameObject.FindWithTag("rule");
        // using (StreamWriter writer = new StreamWriter(Application.streamingAssetsPath+"Save.txt"))
        // {
        //     // Write the string to the file
        //     writer.Write(1 +","+ 1 +","+ 1 +","+x.GetComponent<gamerules>().schedule+","+x.GetComponent<gamerules>().killamount+","+bossi.GetComponent<Boss>().i);
            
        // }
        // using (StreamReader reader = new StreamReader(Application.streamingAssetsPath+ "Save.txt"))
        // {
        //     // Read the entire file and store the string in a variable
        //     fileString = reader.ReadToEnd();

        // }
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosi = GameObject.FindWithTag("Player").transform.position; 
        GameObject bossi = GameObject.FindWithTag("Boss");
        GameObject x = GameObject.FindWithTag("rule");
        TMP=fileString.Split(',');
        //Debug.Log("MISSION"+TMP[3]+TMP[4]);
        if (Input.GetKey(KeyCode.P))
        {
            ContinueLoading();
        }
        
        if(x.GetComponent<gamerules>().schedule==6 || x.GetComponent<gamerules>().schedule==10 || x.GetComponent<gamerules>().schedule==13 || x.GetComponent<gamerules>().schedule==16){
            Debug.Log(playerPosi[0]+"------------------------------------------------"+TMP[3]+TMP[4]);
            SaveMission();
            
        }
        Loading();
    }
    void SaveMission(){
        Vector3 playerPosi = GameObject.FindWithTag("Player").transform.position; 
        GameObject bossi = GameObject.FindWithTag("Boss");
        GameObject x = GameObject.FindWithTag("rule");
        using (StreamWriter writer = new StreamWriter(Application.streamingAssetsPath+"Save.txt"))
            {
                writer.Write(playerPosi[0] +","+ playerPosi[1] +","+ playerPosi[2] +","+x.GetComponent<gamerules>().schedule+","+x.GetComponent<gamerules>().killamount+","+bossi.GetComponent<Boss>().i);

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
    void ContinueLoading(){
        Vector3 playerPosi = GameObject.FindWithTag("Player").transform.position; 
        GameObject bossi = GameObject.FindWithTag("Boss");
        GameObject x = GameObject.FindWithTag("rule");
        using (StreamReader reader = new StreamReader(Application.streamingAssetsPath+ "Save.txt"))
        {
            // Read the entire file and store the string in a variable
            fileString = reader.ReadToEnd();

        }
        Vector3 setplayer = new Vector3(float.Parse(TMP[0]), float.Parse(TMP[1]), float.Parse(TMP[2]));
        GameObject.FindWithTag("Player").transform.SetPositionAndRotation(setplayer,transform.rotation);
        x.GetComponent<gamerules>().schedule=x.GetComponent<gamerules>().Mission(int.Parse(TMP[3])-1);
        x.GetComponent<gamerules>().killamount=int.Parse(TMP[4]);
        if(int.Parse(TMP[3]) >= 13){
            x.GetComponent<gamerules>().keyget=true;
            Destroy(GameObject.Find("Key"));
        }
        if(int.Parse(TMP[3]) >= 16){
            x.GetComponent<gamerules>().BossPostEventDialogue=true;
        }
        bossi.GetComponent<Boss>().i=int.Parse(TMP[5]);
    }
}

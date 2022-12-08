using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadString : MonoBehaviour
{
    // Start is called before the first frame update
    string fileString;
    void Start()
    {
        using (StreamWriter writer = new StreamWriter(Application.streamingAssetsPath+"Save.txt"))
        {
            // Write the string to the file
            writer.Write("13516816,848498,3483438");
            
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
        Debug.Log(string.Join("||", fileString.Split(',')));

    }
}

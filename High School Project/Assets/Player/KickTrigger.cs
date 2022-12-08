using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickTrigger : MonoBehaviour
{
    public void StartKick()
    {
        GetComponent<Collider>().enabled = true;
        Debug.Log("HHHHHHHHHHHHHHHH");
    }
    public void EndKick()
    {
        GetComponent<Collider>().enabled = false;
    }
}

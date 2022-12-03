using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPlacement : MonoBehaviour
{
    private bool ck1 = false, ck2 = false;
    private BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            buildingManager.canPlace = false;
            ck1 = true;
        }
        else
        {
            buildingManager.canPlace = false;
            ck2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ck1 = false;
        }
        else
        {
            ck2 = false;
        }
        if (!ck1 && !ck2)
        {
            buildingManager.canPlace = true;
        }
    }
}
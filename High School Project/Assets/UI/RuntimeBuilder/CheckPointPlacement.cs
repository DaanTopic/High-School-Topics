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
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Zombie")
        {
            buildingManager.canPlace = false;
            ck1 = true;
        }
        else if(other.gameObject.GetComponent<CheckPointPlacement>() != null)
        {
            buildingManager.canPlace = false;
            ck2 = true;
        }
        else
        {
            buildingManager.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Zombie")
        {
            ck1 = false;
        }
        else if (other.gameObject.GetComponent<CheckPointPlacement>() != null)
        {
            ck2 = false;
        }
        if (!ck1 && !ck2)
        {
            buildingManager.canPlace = true;
        }
    }
}
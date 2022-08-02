using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPlacement : MonoBehaviour
{
    private BuildingManager buildingManager;
    bool ck;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            buildingManager.canPlace = false;
            ck = true;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            buildingManager.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ck)
        {
            if (other.gameObject.CompareTag("Object"))
            {
                buildingManager.canPlace = true;
                ck = false;
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player")) buildingManager.canPlace = true;
        }
    }
}

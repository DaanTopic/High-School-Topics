using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPlacement : MonoBehaviour
{
    private BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        buildingManager.canPlace = false;
    }

    private void OnTriggerExit(Collider other)
    {
        buildingManager.canPlace = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPlacement : MonoBehaviour
{
    private BuildingManager buildingManager;
    bool ck = false;
    bool ck1 = false, ck2 = false;
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

            ck1 = true;
             
        }
        if (other.gameObject.CompareTag("Player"))
        {
            buildingManager.canPlace = false;

            ck2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //  if (ck)
        //  {
        
        //OnTriggerEnter(new Collider());
        if (other.gameObject.CompareTag("Object"))
        {
            ck1 = false;
            //  buildingManager.canPlace = true;
            //  ck = false;
            // OnTriggerEnter(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
        }
        //   }
        //   else
        //   {
        if (other.gameObject.CompareTag("Player"))
        {
            ck2 = false;
            //buildingManager.canPlace = true;
            //OnTriggerEnter(GameObject.FindGameObjectWithTag("Object").GetComponent<Collider>());
        }
        
        if (!ck1 && !ck2) buildingManager.canPlace = true;
        // }
    }
}
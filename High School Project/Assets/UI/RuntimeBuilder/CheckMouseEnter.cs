using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckMouseEnter : MonoBehaviour , IPointerExitHandler , IPointerEnterHandler
{
    private Button btn;
    private BuildingManager buildingManager;

    void Start()
    {
        btn = GetComponent<Button>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buildingManager.canPlace = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buildingManager.canPlace = true;
    }
}

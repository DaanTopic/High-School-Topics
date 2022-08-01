using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectManager : MonoBehaviour
{
    public GameObject selectedObject;
    public TextMeshProUGUI objNameText;
    private BuildingManager buildingManager;
    public GameObject objUi;

    void Start(){
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 1000)){
                if (hitInfo.collider.gameObject.CompareTag("Object")){
                    Select(hitInfo.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && selectedObject != null) Deselect();
    }

    private void Select(GameObject obj){
        if (obj == selectedObject) return;
        if (selectedObject != null) Deselect();

        Outline outline = obj.GetComponent<Outline>();
        if(outline == null) obj.AddComponent<Outline>();
        else outline.enabled = true;
        
        objNameText.text = obj.name;
        objUi.SetActive(true);
        selectedObject = obj;
    }

    private void Deselect(){
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
        objUi.SetActive(false);
    }

    public void Delete(){
        GameObject ToDestory = selectedObject;
        Deselect();
        Destroy(ToDestory);
    }
}

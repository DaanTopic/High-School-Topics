using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Inventory.UI;
using Inventory.Model;

public class Build : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject pendingObjects;
    private Vector3 pos;
    private RaycastHit hitInfo;
    [SerializeField] private LayerMask mask;
    public float rotateAmount ,gridSize;
    public GameObject buildUI , objUi;
    public static Vector3 FromWorldPositionToCubePosition(Vector3 position)
    {
        Vector3 resut = Vector3.zero;
        resut.x = position.x > 0 ? (int)position.x * 1f + 0.5f : (int)position.x * 1f - 0.5f;
        resut.y = position.y > 0 ? (int)position.y * 1f + 0.5f : (int)position.y * 1f - 0.5f;
        resut.z = position.z > 0 ? (int)position.z * 1f + 0.5f : (int)position.z * 1f - 0.5f;
        return resut;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            {
                if (buildUI.activeSelf == false)
                {
                    buildUI.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                    objUi.SetActive(false);
                }
                else
                {
                    buildUI.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        if(pendingObjects != null){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            pendingObjects.transform.position = FromWorldPositionToCubePosition(hitInfo.point - ray.direction * 0.001f);

            if (Input.GetMouseButtonDown(0)){
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.R)){
                RotateObject();
            }
        }
    }

    public void PlaceObject(){
        pendingObjects = null;

    }
    public void RotateObject(){
        pendingObjects.transform.Rotate(Vector3.up, rotateAmount);
    }
    private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo, 1000, mask)){
            pos = hitInfo.point;
        }
    }

    public void SelectObject(int index){
        pendingObjects = Instantiate(gameObjects[index], pos, transform.rotation);
    }
}

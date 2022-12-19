using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using System;
using Inventory.UI;
using Inventory.Model;
using Mono.Cecil;
using UnityEngine.InputSystem.XR;
using Inventory;

public class BuildingManager : MonoBehaviour
{
    private Vector3 pos;
    private RaycastHit hitInfo;
    private int index;
    private float rotateAmount = 45.0f;

    public GameObject[] gameObjects, objUI;
    public GameObject pendingObjects;
    public GameObject bu1;
    public GameObject bu2;
    public GameObject bu3;
    public GameObject panel;

    [SerializeField] private Material[] materials;
    [SerializeField] private LayerMask mask;
    
    public bool canPlace = true;
    public GameObject buildUI;
    public ItemSO resource;

    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private GameObject PlayPosition;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
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
            openUI();
        }
        if (pendingObjects != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (pendingObjects.name == "sentryGun(Clone)")
            {
                pendingObjects.transform.position = new Vector3(0f, 1.282f, 0f) + FromWorldPositionToCubePosition(hitInfo.point - ray.direction * 0.001f);
            }
            else pendingObjects.transform.position = FromWorldPositionToCubePosition(hitInfo.point - ray.direction * 0.001f);

            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                var control = GameObject.FindWithTag("Player").GetComponent<InventoryController>();
                control.BuildUse(resource, 1);
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RotateObject();
            }
        }
        UpdateMaterials();
    }

    public void PlaceObject()
    {
        pendingObjects.GetComponent<MeshRenderer>().material = materials[index + 2];
        pendingObjects.GetComponent<Collider>().isTrigger = false;
        objUI[1].SetActive(true);
        if (pendingObjects.name == "sentryGun(Clone)")
        {
            pendingObjects.GetComponent<sentryGun>().enabled = true;
        }
        pendingObjects = null;
    }
    public void RotateObject()
    {
        pendingObjects.transform.Rotate(Vector3.up, rotateAmount);
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo, 1000, mask))
        {
            pos = hitInfo.point;
        }
    }

    private void openUI()
    {
        if (buildUI.activeSelf == false)
        {
            buildUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            
            for(int i = 0;i < objUI.Length; i++)
            {
                objUI[i].SetActive(false);
            }
            

            Vector3 pos = PlayPosition.transform.position;
            pos.y += 5f;

            aimVirtualCamera.gameObject.transform.position = pos;

            aimVirtualCamera.gameObject.SetActive(false);
            aimVirtualCamera.gameObject.SetActive(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));

            bu1.gameObject.SetActive(false);
            bu2.gameObject.SetActive(false);
            bu3.gameObject.SetActive(false);
        }
        else
        {
            reset();
            buildUI.SetActive(false);
            objUI[2].SetActive(true);
            objUI[3].SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;

            aimVirtualCamera.gameObject.SetActive(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
            bu1.gameObject.SetActive(true);
            bu2.gameObject.SetActive(true);
            bu3.gameObject.SetActive(true);
        }
    }

    private void reset()
    {
        if (pendingObjects != null)
        {
            Destroy(pendingObjects);
        }
        canPlace = true;
    }

    void UpdateMaterials()
    {
        if (pendingObjects != null)
        {
            if (canPlace) pendingObjects.GetComponent<MeshRenderer>().material = materials[0];
            else pendingObjects.GetComponent<MeshRenderer>().material = materials[1];
        }
    }

    public void SelectObject(int value)
    {
        reset();
        index = value;
        var control = GameObject.FindWithTag("Player").GetComponent<InventoryController>();
        if (control.Selectnumber(resource) > 0)
        {
            //control.BuildUse(resource, 1);
            objUI[1].SetActive(false);
            pendingObjects = Instantiate(gameObjects[index], pos, transform.rotation);
            pendingObjects.GetComponent<Collider>().isTrigger = true;
        }
    }

    public void Cancel()
    {
        reset();
        objUI[0].SetActive(false);
        objUI[1].SetActive(false);
    }

}

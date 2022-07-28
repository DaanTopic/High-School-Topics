using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Inventory.UI;
using Inventory.Model;
using Cinemachine;
using StarterAssets;

public class Build : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject pendingObjects;
    private Vector3 pos;
    private RaycastHit hitInfo;
    [SerializeField] private LayerMask mask;
    public float rotateAmount, gridSize;
    public GameObject buildUI, objUi;


    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private GameObject PlayPosition ;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
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
            if (buildUI.activeSelf == false)
            {
                buildUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                objUi.SetActive(false);

                Vector3 pos = PlayPosition.transform.position;
                pos.y += 5f;
       
                aimVirtualCamera.gameObject.transform.position = pos;

                aimVirtualCamera.gameObject.SetActive(false);
                aimVirtualCamera.gameObject.SetActive(true);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));


            }
            else
            {

                buildUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;


                aimVirtualCamera.gameObject.SetActive(false);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
            }
        }
        if (pendingObjects != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            pendingObjects.transform.position = FromWorldPositionToCubePosition(hitInfo.point - ray.direction * 0.001f);

            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }
    }

    public void PlaceObject()
    {
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

    public void SelectObject(int index)
    {
        pendingObjects = Instantiate(gameObjects[index], pos, transform.rotation);
    }
}

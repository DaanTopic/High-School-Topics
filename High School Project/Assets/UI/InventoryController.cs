using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private UIIventoryPage inventoryUI;

    public int inventorySize = 10;
    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                inventoryUI.Hide();
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}

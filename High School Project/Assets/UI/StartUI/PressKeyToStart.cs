using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressKeyToStart : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            GetComponent<PressKeyToStart>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}

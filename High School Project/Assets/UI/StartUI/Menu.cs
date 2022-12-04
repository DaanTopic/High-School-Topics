using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int sceneValue;
    public void onMouseEnter()
    {
        GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }
    public void onMouseExit()
    {
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
    }
    public void ClickEvent()
    {
        SceneManager.LoadScene(sceneValue);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
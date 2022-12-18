using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public int sceneValue;
    public void NewGame()
    {
        SceneManager.LoadScene(sceneValue);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Countinue()
    {
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void onMouseEnter()
    {
        GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }
    public void onMouseExit()
    {
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
    }
}
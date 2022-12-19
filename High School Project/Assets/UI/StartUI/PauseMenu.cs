using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI, inGamePanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void Resume()
    {
        inGamePanel.SetActive(true);
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        inGamePanel.SetActive(false);
        Time.timeScale = 0f;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

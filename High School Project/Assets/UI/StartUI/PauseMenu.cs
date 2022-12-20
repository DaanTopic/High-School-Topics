using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera pause;
    public GameObject pauseMenuUI, inGamePanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.gameObject.SetActive(true);
            Pause();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void Resume()
    {
        pause.gameObject.SetActive(false);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int sceneValue;
    private float fadeSpeed = 5f;

    public CanvasGroup canvasGroup;
    public GameObject loadingScene;
    public Image image;
    public Slider slider;

    private bool switchScene = false, fadeIn = false;
    private void Update()
    {
        if (switchScene)
        {
            EndScene();
        }
        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime * 0.5f;
                if (canvasGroup.alpha >= 0.9f)
                {
                    canvasGroup.alpha = 1;
                    fadeIn = false;
                    StartCoroutine(LoadAsynchronously(sceneValue));
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
    IEnumerator LoadAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
    public void NewGame()
    {
        switchScene = true;
    }
    public void Countinue()
    {
        Value.mode = true;
        switchScene = true;
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
    private void FadeToBlack()
    {
        image.color = Color.Lerp(image.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    void EndScene()
    {
        image.enabled = true;
        FadeToBlack();
        if (image.color.a > 0.99f)
        {
            image.color = Color.black;
            switchScene = false;
            loadingScene.SetActive(true);
            fadeIn = true;
        }
    }
}
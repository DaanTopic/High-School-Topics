using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool fadeIn = false, fadeOut = false;
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void FadeIn()
    {
        this.gameObject.SetActive(true);
        fadeIn = true;
    }
    public void FadeOut()
    {
        fadeOut = true;
    }
    private void Update()
    {
        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime * 4f;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime * 4f;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}

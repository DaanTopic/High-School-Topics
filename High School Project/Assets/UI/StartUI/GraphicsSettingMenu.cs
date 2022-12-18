using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicsSettingMenu : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Text_1, Text_2, Text_3, Text_4, Text_5;
    private int index = 2;
    public void FullScreen()
    {
        if (Text_1.text == "On")
        {
            Screen.fullScreen = false;
            Text_1.text = "Off";
        }
        else
        {
            Screen.fullScreen = true;
            Text_1.text = "On";
        }
    }
    public void VSync()
    {
        if (QualitySettings.vSyncCount == 1)
        {
            QualitySettings.vSyncCount = 0;
            Text_2.text = "Off";
        }
        else
        {
            QualitySettings.vSyncCount = 1;
            Text_2.text = "On";
        }
    }
    public void SetShadows()
    {
        switch (Text_3.text)
        {
            case "Soft":
                QualitySettings.shadows = ShadowQuality.All;
                Text_3.text = "Hard";
                break;
            case "Off":
                QualitySettings.shadows = ShadowQuality.HardOnly;
                Text_3.text = "Soft";
                break;
            case "Hard":
                QualitySettings.shadows = ShadowQuality.Disable;
                Text_3.text = "Off";
                break;
        }
    }
    public void SetQuality()
    {
        index++;
        if (index > 2) index = 0;
        QualitySettings.SetQualityLevel(index);
        switch (index)
        {
            case 0:
                Text_4.text = "Low";
                break;
            case 1:
                Text_4.text = "Meduim";
                break;
            case 2:
                Text_4.text = "High";
                break;
        }
    }
    public void SetResolution()
    {
        switch (Text_5.text)
        {
            case "1366 X 768":
                Screen.SetResolution(1920, 1080, true);
                Text_5.text = "1920 X 1080";
                break;
            case "1024 X 768":
                Screen.SetResolution(1366, 768, true);
                Text_5.text = "1366 X 768";
                break;
            case "1920 X 1080":
                Screen.SetResolution(1024, 768, true);
                Text_5.text = "1024 X 768";
                break;
        }
    }
}

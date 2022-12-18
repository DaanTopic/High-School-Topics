using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsSettingMenu : MonoBehaviour
{
    private int index = 0;
    public void SetQuality()
    {
        index++;
        if (index > 2) index = 0;
        QualitySettings.SetQualityLevel(index);
        //switch (index)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        break;
        //    case 2:
        //        break;
        //}
    }
}

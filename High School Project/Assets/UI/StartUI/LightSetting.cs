using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetting : MonoBehaviour
{
    private Light lightComponent;
    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    void Update()
    {
        lightComponent.intensity = Value.Brightness;
        switch (Value.Shadows)
        {
            case 0:
                lightComponent.shadows = LightShadows.Hard;
                break;
            case 1:
                lightComponent.shadows = LightShadows.Soft;
                break;
            case 2:
                lightComponent.shadows = LightShadows.None;
                break;
        }
    }
}

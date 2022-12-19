using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainSettingMenu : MonoBehaviour
{
    // public AudioMixer audioMixer;

    // private int index;
    public void SetBrightness(float value)
    {
        Value.Brightness = value;
    }
    public void SetContrast(float value)
    {
        Value.Contrast = value;
    }
    public void SetVolume(float value)
    {
        // audioMixer.SetFloat("Volume", value);
        Value.GunAudioVolume = value;
    }
}

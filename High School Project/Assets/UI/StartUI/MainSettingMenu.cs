using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainSettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private int index;
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }
}

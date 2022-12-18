using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KickTrigger : MonoBehaviour
{
    float volume = 1.5F;
    SoundManager SoundManager;

    void Start()
    {
        SoundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }
    public void StartKick()
    {
        GetComponent<Collider>().enabled = true;

        AudioSource.PlayClipAtPoint(SoundManager.KickSound, SoundManager.PlayerSoundPosi, volume);
    }
    public void EndKick()
    {
        GetComponent<Collider>().enabled = false;
    }
}

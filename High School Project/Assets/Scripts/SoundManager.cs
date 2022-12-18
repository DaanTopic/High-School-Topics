using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip KickSound;
    public GameObject Player;
    public Vector3 PlayerSoundPosi;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       PlayerSoundPosi = GameObject.FindWithTag("Player").transform.position;
    }
}

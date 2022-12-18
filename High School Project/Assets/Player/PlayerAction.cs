using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAction : MonoBehaviour
{
    private Animator anim;
    public bool isAttack = false;
    public GameObject Leg;
    private void Awake() {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("MouseRight", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("MouseRight", false);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetBool("Kick", true);
        }
    }
    void StartKick()
    {
        isAttack = false;
        Leg.GetComponent<KickTrigger>().StartKick();
    }
    void EndKick()
    {
        Leg.GetComponent<KickTrigger>().EndKick();
        Debug.Log("buffer");
        anim.SetBool("Kick", false);
    }
}
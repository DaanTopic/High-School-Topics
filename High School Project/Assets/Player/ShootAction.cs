using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
        private void Awake() {
        animator=GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            animator.SetBool("MouseRight",true);
        }
        if(Input.GetMouseButtonUp(1)){
            animator.SetBool("MouseRight",false);
        }
    }
}

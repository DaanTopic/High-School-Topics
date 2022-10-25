using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControlier : MonoBehaviour
{
    [Tooltip("巡邏範圍")]
    [SerializeField] float PatrolRange = 5;
    [Tooltip("巡邏誤差範圍")]
    [SerializeField] float PatrolError = 1;
    [Tooltip("困惑時間")]
    [SerializeField] float Times = 5;
    Mover mover;
    Animator animator;
    private float AiTimes=1000;

    private void Awake() {
        mover = GetComponent<Mover>();
        animator=GetComponent<Animator>();
    }
    
    Vector3 setAI;
    Vector3 home;
    public Transform Player;
    // Update is called once per frame
    private void Start() {
        Debug.Log("觸發開始");
        setAI = transform.position;
        home = transform.position;
        Debug.Log(setAI);
    }
    bool find = false;
    void Update()
    {
        //&& Input.GetKey(KeyCode.LeftShift)
        if(Vector3.Distance(transform.position,Player.position)<=10){
            Debug.Log("我發現你了");
            find=true;
            AiTimes=0;
        }
        else if(Vector3.Distance(transform.position, Player.position) <= 30 && find){
            Debug.Log("我發現你了");
            find=true;
            AiTimes=0;
        }
        else if(Vector3.Distance(transform.position, Player.position) > 30){
            Debug.Log("我追不到你了");
            find=false;
        }
        if(find){
            mover.MoveTo(Player.transform.position, 10);
            animator.SetFloat("WalkSpeed",1f);
        }
        if(!find){
            if (AiTimes<Times){
                Debug.Log("我好困惑");
                mover.CancelMove();
                animator.SetBool("Turn",true);
                Debug.Log(AiTimes);
            }
            else if(Vector3.Distance(transform.position,home)<=PatrolError){
                float AIx = Random.Range(-PatrolRange,PatrolRange);
                float AIz = Random.Range(-PatrolRange,PatrolRange);
                Vector3 ran = new Vector3(AIx,0,AIz);
                home = setAI + ran;
                
            }
            else{
                Debug.Log("我要回家");
                Debug.Log(Vector3.Distance(transform.position,home));
                animator.SetBool("Turn",false);
                mover.MoveTo(home,0.5f);
                animator.SetFloat("WalkSpeed",0.5f);
                
            }
            

        }
        Updatetime();
    }
    private void Updatetime(){
        AiTimes += 0.01f;
    }
}

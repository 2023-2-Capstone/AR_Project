using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController : MonoBehaviour
{
    //애니메이션을 연결
    public Animator anim;
    private bool isIdle = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                if (isIdle)
                {   
                    Debug.Log("Idle")
                    anim.SetTrigger("IdleToRun");
                    isIdle = false;
                }   
                else
                {
                    anim.SetTrigger("RunToIdle");
                    isIdle = true;
                }
            }
            
        }
    }
}

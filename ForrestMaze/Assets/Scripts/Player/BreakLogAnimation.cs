using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLogAnimation : MonoBehaviour
{

    int timeBetweenHits = 1;
    int timeLeftBetweenHits = 0;
   
    Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gameObject.GetComponent<PlayerIneventory>().axeInPosesion)
            {
                if (Time.time >= timeLeftBetweenHits)
                {
                    timeLeftBetweenHits = (int)(Time.time + timeBetweenHits);
                    animator.SetFloat("AxeSwing", 1f);
                }
            }
        }else if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetFloat("AxeSwing", 0f);
        }
    }
}

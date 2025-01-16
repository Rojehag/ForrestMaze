using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeattack : MonoBehaviour
{
    public GameObject attackObject;

    public float time;

    

    public float timeBetweenAttack;
    float timeLeftBetweenAttack;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time >= timeLeftBetweenAttack)
        {
            
            timeLeftBetweenAttack = Time.time + timeBetweenAttack;
            Attack();
        }

        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            animator.SetFloat("Hit", 0f);


        }

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                animator.SetFloat("Hit", 1f);

            }
             


            GameObject playerAttack = Instantiate(attackObject, transform.position + transform.up, Quaternion.Euler(0, 0, 0));
            Rigidbody2D playerRigidbody = playerAttack.GetComponent<Rigidbody2D>();
            Destroy(playerAttack, time);

           


        }
    }
}
 
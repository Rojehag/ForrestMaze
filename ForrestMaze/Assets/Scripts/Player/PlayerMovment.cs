using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
    Rigidbody2D rigidbody;

    //To get the speed it will multiply with the vector later
    public int speed;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //Getting the rigidbody
        rigidbody = GetComponent<Rigidbody2D>();

        //Set speed for begining
        rigidbody.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //To being able to stop
        rigidbody.velocity = new Vector2(0, 0);

        // Movment
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = new Vector2(0, 1) * speed;
            rigidbody.rotation = 0;
            animator.SetFloat("Run", speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = new Vector2(0, -1) * speed;
            rigidbody.rotation = 180;
            animator.SetFloat("Run", speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-1, 0) * speed;
            rigidbody.rotation = 90;
            animator.SetFloat("Run", speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(1, 0) * speed;
            rigidbody.rotation = -90;
            animator.SetFloat("Run", speed);
        }
        else
        {
            animator.SetFloat("Run", 0f);
        }
    }
}

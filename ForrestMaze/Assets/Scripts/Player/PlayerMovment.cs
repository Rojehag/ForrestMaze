using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
    Rigidbody2D rigidbody;

    //To get the speed it will multiply with the vector later
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
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
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = new Vector2(0, -1) * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-1, 0) * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(1, 0) * speed;
        }
    }
}

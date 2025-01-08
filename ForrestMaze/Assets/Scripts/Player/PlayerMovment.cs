using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(0, 0);

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

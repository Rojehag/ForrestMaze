using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeattack : MonoBehaviour
{
    public GameObject attackObject;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject playerAttack = Instantiate(attackObject, transform.position + transform.up, Quaternion.Euler(0, 0, 0));
            Rigidbody2D playerRigidbody = playerAttack.GetComponent<Rigidbody2D>();
            Destroy(playerAttack, time);
        }
        
    }
}
 
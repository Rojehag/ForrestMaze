using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    bool playerNearby = false;
    public GameObject healthPack;

    float time = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerNearby == true) 
            {
                if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerHealth>().currentHealth < 3)
                {
                    Destroy(healthPack, time);
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            playerNearby = false;
        }
    }
}

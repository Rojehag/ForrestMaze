using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIneventory : MonoBehaviour
{
    public bool axeInPosesion = false;

    bool axeNearby = false;
    
    public GameObject axe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (axeNearby == true)
            {
                axeInPosesion = true;

                Destroy(axe, 0.1f);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            axeNearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            axeNearby = false;
        }
    }
}

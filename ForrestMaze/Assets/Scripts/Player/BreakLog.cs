using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLog : MonoBehaviour
{
    bool playerNearby = false;

    public int logHealth = 3;

    int timeBetweenHits = 1;
    int timeLeftBetweenHits = 0;
    public GameObject log;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (logHealth <= 0)
        {
            Destroy(log, 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(Time.time >= timeLeftBetweenHits)
            {
                timeLeftBetweenHits = (int) (Time.time + timeBetweenHits);
                HitLog();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            playerNearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            playerNearby = false;
        }
    }
    void HitLog()
    {
        if (GameObject.FindGameObjectWithTag("player").GetComponent<PlayerIneventory>().axeInPosesion)
        {
            if (playerNearby == true)
            {
                logHealth -= 1;
            }
        }
    }
}

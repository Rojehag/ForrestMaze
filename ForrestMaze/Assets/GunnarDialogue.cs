using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnarDialogue : MonoBehaviour
{

    bool isPlayerNearby = false;
    public GameObject dialogText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearby == true)
        {
            print("Do you mind talking a minute with an old man");
            //Visa UI-texten
            dialogText.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Come here young man!");
        isPlayerNearby = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerNearby = false;
        dialogText.SetActive(false);
    }
} 
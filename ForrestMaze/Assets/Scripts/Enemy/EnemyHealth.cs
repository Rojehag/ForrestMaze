using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    
    bool playerTag;

    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;



    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(enemy);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        

        if (collider.gameObject.CompareTag("PlayerAttack"))
        {
            
            currentHealth -= 1;
        }
    }

    
}

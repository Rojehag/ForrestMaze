using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;

    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public float remaningHealthProcentage
    {
        get
        {
            return currentHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void GameOver()
    {

    }
}

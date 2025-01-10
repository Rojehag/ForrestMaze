using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    bool enemyTag;
    bool armOut;
    


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;

    }

    //So you can die
    void Update()
    {
        if (currentHealth <= 0)
        {
            GameOver();
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            armOut = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            armOut = false;
        }
    }

    //For health bar
    public float remaningHealthProcentage
    {
        get
        {
            return currentHealth;
        }
    }

    //So you only take damage from enemys
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (armOut == true)
            {

            }
            else if(armOut == false)
            {
                currentHealth -= 1;
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}

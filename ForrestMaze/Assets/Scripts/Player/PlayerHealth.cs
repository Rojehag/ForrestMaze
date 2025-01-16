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

    bool isNearHealth = false;

    public GameObject lives;


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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isNearHealth) 
            {
                if (currentHealth < 3)
                {
                    currentHealth += 1;
                    lives.transform.GetChild(currentHealth - 1).gameObject.SetActive(true);

                }
            }

        }

    }

    //So you only take damage from enemys
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Health pack") )
        {
            isNearHealth = true;
           
        }


        if (collider.gameObject.CompareTag("Enemy"))
        {
            
            currentHealth -= collider.gameObject.GetComponent<PlayerAttackArea>().damageAmount;

            // Destory(lives.transform.GetChild(currentHealth).gameObject);
            lives.transform.GetChild(currentHealth).gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health pack") )
        {
            isNearHealth = false;

        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}

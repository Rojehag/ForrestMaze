using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    float time = 0.5f;
    public float timeWhileblocking = 0.5f;

    float timeBetweenBlock = 1.5f;
    float timeLeftBetweenBlock = 0;

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
        timeWhileblocking -= Time.deltaTime;

        if (currentHealth <= 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time >= timeLeftBetweenBlock)
            {
                timeLeftBetweenBlock = Time.time + timeBetweenBlock;
                armOut = true;
                timeWhileblocking = time;
            }
        }
        else if (timeWhileblocking <= 0)
        {

            armOut = false;


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

        if (armOut == false)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {

                currentHealth -= collider.gameObject.GetComponent<PlayerAttackArea>().damageAmount;

                // Destory(lives.transform.GetChild(currentHealth).gameObject);
                lives.transform.GetChild(currentHealth).gameObject.SetActive(false);

            }
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

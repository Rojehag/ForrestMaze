using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    bool enemyTag;

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 1;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemmyAttackArea;
    public float timeOfAttack;
    float enemyTimeBetweenAttack = 2;
    float enemyTimeLeftBetweenAttack = 0;

    bool enemyNearby = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNearby)
        {
            if (Time.time >= enemyTimeLeftBetweenAttack)
            {
                enemyTimeLeftBetweenAttack = Time.time + enemyTimeBetweenAttack;
                EnemyAttacking();
            }

           
        }  
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {

        
        if (collider.gameObject.CompareTag("player"))
        {
            enemyNearby = true;

           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            enemyNearby = false;
        }
    }

    void EnemyAttacking()
    {
        GameObject enemyAttack = Instantiate(enemmyAttackArea, transform.position + transform.up, Quaternion.Euler(0, 0, 0));
        Rigidbody2D enemnyRigidbody = enemyAttack.GetComponent<Rigidbody2D>();

        animator.Play("ZombieHit");

        Destroy(enemyAttack, timeOfAttack);
    }
}

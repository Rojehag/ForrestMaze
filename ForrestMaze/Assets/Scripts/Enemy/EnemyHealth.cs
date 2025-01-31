using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    
    bool playerTag;

    public GameObject enemy;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            animator.Play("EnemyDie");
            
            Destroy(enemy, 0.7f);

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        

        if (collider.gameObject.CompareTag("PlayerAttack"))
        {
            if (Random.Range(0, 10) == 5)
            {
                currentHealth -= collider.gameObject.GetComponent<PlayerAttackArea>().damageAmount * 2;
            }
            else
            {
                currentHealth -= collider.gameObject.GetComponent<PlayerAttackArea>().damageAmount;
            }
        }
    }

    
}

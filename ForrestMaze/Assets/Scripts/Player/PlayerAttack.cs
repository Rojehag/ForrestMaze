using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    private float startTimeBetweenAttack;

    public Transform attackPosition;
    public LayerMask whatIsEnemys;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            // Then you can attack
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemys); 
            }
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }
}

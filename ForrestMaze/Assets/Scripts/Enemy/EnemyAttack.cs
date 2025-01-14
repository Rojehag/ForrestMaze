using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemmyAttackArea;
    public float timeOfAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
         
        GameObject enemyAttack = Instantiate(enemmyAttackArea, transform.position + transform.up, Quaternion.Euler(0, 0, 0));
        Rigidbody2D enemnyRigidbody = enemyAttack.GetComponent<Rigidbody2D>();
        
        Destroy(enemyAttack, timeOfAttack);
    }
}

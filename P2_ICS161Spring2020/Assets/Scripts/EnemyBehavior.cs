using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float health = 100.0f;  //currently, bullet does 100.0f damage so it one-shots enemies

    private float damageRecieved;

    public void TakeDamage(float damageRecieved)
    {
        health-=damageRecieved;
        if(health <= 0.0f) Die();
    }

    
    void Die()
    {
        Destroy(gameObject);
    }
}

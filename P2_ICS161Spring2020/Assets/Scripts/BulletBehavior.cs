using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 25.0f;
    private float damage = 25.0f;

    public GameObject instantiator; //the player that fired the bullet

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        PlayerStatManager enemyPlayer = collider.GetComponent<PlayerStatManager>();
        if (enemyPlayer != null && collider != instantiator.GetComponent<Collider>())
        {
            enemyPlayer.TakeDamage(damage);
        }
        Destroy(gameObject);    //destroys bullet
    }
}

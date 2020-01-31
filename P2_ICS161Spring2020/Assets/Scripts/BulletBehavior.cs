using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 25.0f;
    
    [SerializeField]
    private float damage = 100.0f;


    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log(collider.gameObject.name);
        PlayerStatManager enemyPlayer = collider.GetComponent<PlayerStatManager>();
        if (enemyPlayer != null)
        {
            enemyPlayer.TakeDamage(damage);
        }
        Destroy(gameObject);    //destroys bullet


    }
}

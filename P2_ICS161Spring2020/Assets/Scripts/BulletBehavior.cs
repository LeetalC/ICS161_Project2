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

    [SerializeField]
    private Rigidbody bulletRB;

  //  EnemyBehavior Enemy;
    PlayerStatManager aPlayer;

    void Start()
    {
        bulletRB.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider collider)
    {
      // Debug.Log(collider.gameObject.name);
        aPlayer = collider.GetComponent<PlayerStatManager>();
        if (aPlayer != null)
        {
            aPlayer.TakeDamage(GetDamage());

        }
        //if(collider.gameObject.name != "Player")
        Destroy(gameObject);    //destroys bullet


    }

    public float GetDamage() 
    {
        return damage;
    }
    public float GetSpeed()
    {
        return speed;
    }



}

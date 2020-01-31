using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    private float health;  //currently, bullet does 100.0f damage so it one-shots enemies
    private float damageRecieved;
    private bool isDead;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    [SerializeField]
    private GameObject player;
   

    void Start()
    {
        startingPosition = player.GetComponent<Transform>().position;
        startingRotation = player.GetComponent<Transform>().rotation;
        Debug.Log("YOLO" + startingPosition);
        health = 100.0f;
        isDead = false;
    }
    public void TakeDamage(float damageRecieved)
    {
        health -= damageRecieved;
        if (health <= 0.0f)
        {
            isDead = true;
            Resurrect();
        }
    }

    public void Resurrect()
    {
        Instantiate(player, startingPosition, Quaternion.Identity);
    }
}

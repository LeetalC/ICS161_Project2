using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    private float health;  //currently, bullet does 100.0f damage so it one-shots enemies
    private float damageRecieved;
    private bool isDead;
    [SerializeField]    
    private Vector3 startingPosition;

    [SerializeField]
    private Quaternion startingRotation;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private GameObject player;
    private GameObject[] colorableParts;

    [SerializeField]
    private Material color;

    void Start()
    {
        StatInit();
        AssignColor();
    }
    private void StatInit() 
    {
        startingPosition = playerTransform.GetComponent<Transform>().position;
        startingRotation = playerTransform.GetComponent<Transform>().rotation;
        health = 100.0f;
        isDead = false;
    }
    private void AssignColor()
    {
        foreach(Transform child in transform)
        {
            if(child.tag == "ColorablePart")
            {
                child.GetComponent<MeshRenderer>().material = color;
            }
        }
    }
    public Material GetColor()
    {
        return color;
    }

    public void TakeDamage(float damageRecieved)
    {
        health -= damageRecieved;
        if (health <= 0.0f)
        {
            isDead = true;
            Die();
        }
    }
    void Die() 
    {    
        Debug.Log(player.name + " has died!");
        Resurrect();
    }

    public void Resurrect()
    {
       playerTransform.position = startingPosition;
       playerTransform.rotation = startingRotation;
    }

    
}

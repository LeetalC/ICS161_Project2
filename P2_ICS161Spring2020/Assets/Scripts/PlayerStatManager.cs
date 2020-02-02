using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
 
    private float health;  //currently, bullet does 50.0f damage so it one-shots enemies
    private float damageRecieved;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

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
        startingPosition = transform.GetComponent<Transform>().position;
        startingRotation = transform.GetComponent<Transform>().rotation;
        health = 100.0f;
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
        Debug.Log(gameObject.name + " has taken " + damageRecieved + " damage.");
        if (health <= 0.0f)
        {
            Die();
        }
    }
    void Die() 
    {    
        Debug.Log(gameObject.name + " has died!");
        Resurrect();
    }

    public void Resurrect()
    {
       health = 100.0f;
       transform.position = startingPosition;
       transform.rotation = startingRotation;
      
    }

    
}

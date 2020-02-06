using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
 
    private float health;  //currently, bullet does 50.0f damage so it one-shots enemies
    private float damageRecieved;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private GameObject[] colorableParts;

    [SerializeField]
    private Material color;

    [SerializeField]
    private Text healthText;

    void Start()
    {
        StatInit();
        AssignColor();
    }

    private void StatInit() 
    {
        startingPosition = transform.GetComponent<Transform>().position;
        startingRotation = transform.GetComponent<Transform>().rotation;
        UpdateHealth(100.0f);
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
        UpdateHealth(health - damageRecieved);
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
       UpdateHealth(100.0f);
       transform.position = startingPosition;
       transform.rotation = startingRotation;
      
    }

    private void UpdateHealth(float hp)
    {
        health = hp;
        healthText.text = health.ToString();
    }

    
}

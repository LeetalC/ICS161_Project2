using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
 
    private float health;  //bullet does 25 dmg
    private float damageRecieved;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private GameObject[] colorableParts;    //this is a Tag i made in the game, it determines which parts of the player can be colored

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

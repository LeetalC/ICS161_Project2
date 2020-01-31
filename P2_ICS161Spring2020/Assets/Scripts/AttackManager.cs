using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private Transform firingPoint;
    
    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private GameObject player1;
    [SerializeField]

    private GameObject player2;


    void Update()
    {
        if(Input.GetKeyDown("space")) Shoot();
        if(Input.GetKey(KeyCode.RightArrow)) Shoot();
    }
    
    void Shoot() 
    {
        Instantiate(Bullet, firingPoint.position, firingPoint.transform.rotation);
        //i would like to change the material of each bullet
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private Transform firingPoint;  //where bullets will spawn
    
    [SerializeField]
    private GameObject Bullet;

    private KeyCode playerAttackButton;
    static bool controlsAssigned = false;

    void Start()
    {
        AssignControls();
    }

    void Update()
    {
        if (Input.GetKeyDown(playerAttackButton)) Shoot();
    }
    void AssignControls() 
    {
        if (controlsAssigned == false)
        {
            playerAttackButton = KeyCode.Space;
            controlsAssigned = true;
        }
        else playerAttackButton = KeyCode.Period;
    }
    void Shoot() 
    {
        Bullet.GetComponent<BulletBehavior>().instantiator = gameObject;
        Bullet.transform.GetChild(0).GetComponent<MeshRenderer>().material = gameObject.GetComponent<PlayerStatManager>().GetColor();
        Instantiate(Bullet, firingPoint.position, firingPoint.transform.rotation);

    }
}

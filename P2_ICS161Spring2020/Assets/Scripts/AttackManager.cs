using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private Transform firingPoint;
    
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
        Instantiate(Bullet, firingPoint.position, firingPoint.transform.rotation);
        Bullet.transform.GetChild(0).GetComponent<MeshRenderer>().material = gameObject.GetComponent<PlayerStatManager>().GetColor();

    }
}

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
    private GameObject player;
    private KeyCode playerAttackButton;

    [SerializeField]
    private PlayerStatManager aPlayer;
    void Start()
    {
        AssignControls();
    }
    void Update()
    {
        if(Input.GetKeyDown(playerAttackButton)) Shoot();
    }
    void AssignControls() 
    {
        if(player.name == "Player1") playerAttackButton = KeyCode.Space;
        else playerAttackButton = KeyCode.Period;
    }
    void Shoot() 
    {
        Instantiate(Bullet, firingPoint.position, firingPoint.transform.rotation);
        Bullet.transform.GetChild(0).GetComponent<MeshRenderer>().material = aPlayer.GetColor();
    }
}

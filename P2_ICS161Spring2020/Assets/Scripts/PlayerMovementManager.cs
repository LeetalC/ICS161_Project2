using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    private Quaternion currentRotation;

    [SerializeField]
    private float speed;

    private KeyCode[] player1Controls = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    private KeyCode[] player2Controls = {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    private KeyCode[] thisPlayersControls;
    static bool controlsAssigned = false;

    enum Directions
    {
        North = 0,
        South = -180,
        Right = -90,
        Left = 90

    }

    void Start()
    {

        speed = 5.0f;
        AssignControls();
    } 

    void Update()
    {
        MoveCharacter();
    }

    private void AssignControls()
    {
        if (controlsAssigned == false)
        {
            thisPlayersControls = player1Controls;
            controlsAssigned = true;
        }
        else thisPlayersControls = player2Controls;
    }
    private void MoveCharacterHelper(Vector3 rot) {

        //transform.rotation = Quaternion.Euler(rot);
        transform.position += transform.forward * Time.deltaTime * speed;
         transform.rotation = Quaternion.Euler(rot);
    }

    private void MoveCharacter(){
        if (Input.GetKey(thisPlayersControls[0])) 
        {
           MoveCharacterHelper(new Vector3(0, 0, 0));
        }
        else if(Input.GetKey(thisPlayersControls[1])) 
        {
            MoveCharacterHelper(new Vector3(0, -180, 0));
        }
        else if (Input.GetKey(thisPlayersControls[2]))
        {
            MoveCharacterHelper(new Vector3(0, -90, 0));
        }
        else if(Input.GetKey(thisPlayersControls[3])) 
        {
            MoveCharacterHelper(new Vector3(0, 90, 0));
        }
    }

}

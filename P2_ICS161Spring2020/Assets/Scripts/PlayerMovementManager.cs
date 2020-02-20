using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    private Quaternion currentRotation;

    [SerializeField]
    private float speed;


    private KeyCode[] player1Controls = {KeyCode.W, KeyCode.A,KeyCode.S, KeyCode.D};
    private KeyCode[] player2Controls = {KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow};
    private KeyCode[] thisPlayersControls;
    static bool controlsAssigned = false;


    void Start()
    {
        currentRotation = gameObject.GetComponent<Transform>().rotation;
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
    private void MoveCharacterHelper(int orientation) {
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(new Vector3(0,orientation,0) + currentRotation.eulerAngles);
    }

    private void MoveCharacter(){
        if (Input.GetKey(thisPlayersControls[0])) 
        {
           MoveCharacterHelper(0);
        }
        else if (Input.GetKey(thisPlayersControls[1]))
        {
            MoveCharacterHelper(-90);
        }
        else if(Input.GetKey(thisPlayersControls[2])) 
        {
            MoveCharacterHelper(-180);
        }
        else if(Input.GetKey(thisPlayersControls[3])) 
        {
            MoveCharacterHelper(90);
        }
    }

}

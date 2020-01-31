using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    private Quaternion currentRotation;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody playerRigidBody;

    [SerializeField]
    private GameObject player;

    private KeyCode[] player1Controls = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    private KeyCode[] player2Controls = {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    private KeyCode[] thisPlayersControls;


    void Start()
    {
        speed = 5.0f;
        AssignControls();
    }

    // Player can only move in the four cardinal directions. 
    void Update()
    {
        MoveCharacter();
    }
    private void AssignControls()
    {
        if (player.name == "Player1") thisPlayersControls = player1Controls;
        else thisPlayersControls = player2Controls;
    }
    private void MoveCharacterHelper(Vector3 eulerVec) {
        transform.rotation = Quaternion.Euler(eulerVec);
        transform.position += transform.forward * Time.deltaTime * speed;
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

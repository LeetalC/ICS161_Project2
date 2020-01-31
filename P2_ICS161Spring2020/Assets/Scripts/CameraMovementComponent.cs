using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementComponent : MonoBehaviour
{
    [SerializeField]    
    private Transform player1;

    [SerializeField]    
    private Transform player2;

    [SerializeField]
    private Vector3 cameraOffset;

    void LateUpdate()
    {
      //  transform.position = (player2.position + player1.position) + cameraOffset;
       // Debug.Log(transform.position);
    }

}

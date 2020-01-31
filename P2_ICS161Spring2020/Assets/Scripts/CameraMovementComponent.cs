using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementComponent : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 cameraOffset;

    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
    }

}

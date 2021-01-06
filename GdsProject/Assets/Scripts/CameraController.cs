using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float xOffset;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = xOffset;
        
        transform.position = currentPosition;
        
        
    }
}

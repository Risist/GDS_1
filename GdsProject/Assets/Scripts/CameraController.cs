using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;

    public float xOffset;

    private void Start()
    {
        var player = FindObjectOfType<PlayerInputHolder>();
        target = player.transform;
    }

    void Update()
    {
        if (!target)
            return;

        Vector3 targetPosition = target.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = targetPosition.x + xOffset;
        
        transform.position = currentPosition;
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public CarWheelsController carWheels;
    public Transform moveObject;
    float moveObjectX = 0;
    public float moveSpeed;
    void Update()
    {
        moveObjectX = moveObjectX + moveSpeed;

        /*if (GroundTileManager.instance.GetTopPosition(moveObjectX, out var position))
        {
            moveObject.position = position;
        }*/

        carWheels.UpdateWheelPosition(moveObjectX);
        
    }
}

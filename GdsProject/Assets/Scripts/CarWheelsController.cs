using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheelsController : MonoBehaviour
{
    [System.Serializable]
    public struct WheelRecord
    {
        public GameObject wheelObject;
        // in texture units
        public float xOffset;
    }
    public WheelRecord[] wheels;

    // int world units
    public float wheelYOffset;
    // int world units
    public float carYOffset;

    public void UpdatePosition(float x)
    {
        Vector3 averageWheelPosition = Vector3.zero;
        float maxWheelY = float.MinValue;
        int nWheels = 1;

        foreach (var it in wheels)
        {
            if(GroundTileManager.instance.GetTopPosition(x + it.xOffset, out var position))
            {
                position = position + Vector3.up * wheelYOffset;
                it.wheelObject.transform.position = position;

                averageWheelPosition += position;
                ++nWheels;

                if (position.y > maxWheelY)
                    maxWheelY = position.y;
            }
        }
        averageWheelPosition /= nWheels;

        {
            if (GroundTileManager.instance.GetTopPosition(x, out var position))
            {
                Vector3 carPosition = new Vector3(position.x, maxWheelY + carYOffset);
                transform.position = carPosition;
            }
        }
    }

    
}

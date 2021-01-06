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
    public float defaultWheelYOffset;
    // int world units
    public float carYOffset;

    public float lastTextureHeight { get; private set; }

    public void UpdateWheelPosition(float x)
    {
        float maxWheelY = float.MinValue;

        foreach (var it in wheels)
        {
            if(GroundTileManager.instance.GetTopPosition(x + it.xOffset, out var position))
            {
                position.y += wheelYOffset;
                it.wheelObject.transform.position = position;

                if (position.y > maxWheelY)
                    maxWheelY = position.y;
            }
        }

        if (GroundTileManager.instance.GetTopPosition(x, out var carPosition))
        {
            carPosition = new Vector3(carPosition.x, maxWheelY + carYOffset);
            transform.position = carPosition;
        }
    }

    public void SetWheelDefaultPosition(float x, float height)
    {
        foreach (var it in wheels)
        {
            if (GroundTileManager.instance.GetTopPosition(x + it.xOffset, out var position))
            {
                position.y = height + defaultWheelYOffset;
                it.wheelObject.transform.position = position;
            }
        }

        if (GroundTileManager.instance.GetTopPosition(x, out var carPosition))
        {
            carPosition.y = height + carYOffset;
            transform.position = carPosition;
        }
    }
    
}

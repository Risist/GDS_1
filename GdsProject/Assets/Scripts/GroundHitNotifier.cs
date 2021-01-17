using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitNotifier : MonoBehaviour
{
    void Update()
    {
        float height;
        if (!GroundTileManager.instance.GetWorldHeight_WorldCoords(transform.position.x, out height))
            return;
        
        if(height >= transform.position.y)
        {
            BroadcastMessage("OnGroundHit", height);
        }
    }
}

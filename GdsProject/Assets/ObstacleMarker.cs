using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMarker : MonoBehaviour
{
    static List<ObstacleMarker> _markers = new List<ObstacleMarker>();

    public static Vector3 FindClosestFreePosition( Vector3 peendingPosition, float freeArea, float nextTestOffset)
    {
        while(!IsFreePosition(peendingPosition, freeArea))
        {
            peendingPosition.x += nextTestOffset;
        }
        return peendingPosition;
    }
    public static bool IsFreePosition(Vector3 peendingPosition, float freeArea)
    {
        foreach(var it in _markers)
        {
            if( (it.transform.position - peendingPosition).sqrMagnitude < freeArea*freeArea)
            {
                return false;
            }
        }
        return true;
    }



    private void OnEnable()
    {
        _markers.Add(this);
    }
    private void OnDisable()
    {
        _markers.Remove(this);
    }
}

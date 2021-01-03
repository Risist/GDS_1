using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHole : MonoBehaviour
{
    public float radius;

    private void Start()
    {
        GroundTileManager.instance.CutHoleInGround(transform.position, radius * 0.5f * transform.localScale.x);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitNotifier : MonoBehaviour
{
    public float explosionCreationOffset = 0.25f;
    public string heightObjectTag = "GroundHeight";
    float height;

    private void Start()
    {
        var heightObject = GameObject.FindGameObjectWithTag(heightObjectTag)?.transform;
        height = heightObject.position.y - explosionCreationOffset;
    }

    void Update()
    {
        if (transform.position.y < height)
        {
            BroadcastMessage("OnGroundHit", height);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnGroundHit : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 offset;
    void OnGroundHit(float height)
    {
        var obj = Instantiate(prefab, transform.position, transform.rotation);
        Vector3 position = obj.transform.position;
        position.y = height;
        position += offset;

        obj.transform.position = position;
    }
}

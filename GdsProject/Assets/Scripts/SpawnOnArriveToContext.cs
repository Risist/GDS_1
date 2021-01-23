using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnArriveToContext : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 offset;
    void OnArriveToContext(Vector3 target)
    {
        var obj = Instantiate(prefab, transform.position, transform.rotation);
        Vector3 position = obj.transform.position;
        position.x = target.x;
        position.y = target.y;
        position += offset;

        obj.transform.position = position;
    }
}

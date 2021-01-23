using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnArriveToContext : MonoBehaviour
{
    void OnArriveToContext(Vector3 target)
    {
        Destroy(gameObject);
    }
}

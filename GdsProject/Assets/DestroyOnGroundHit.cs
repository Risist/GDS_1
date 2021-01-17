using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGroundHit : MonoBehaviour
{
    void OnGroundHit(float height)
    {
        Destroy(gameObject);
    }
}

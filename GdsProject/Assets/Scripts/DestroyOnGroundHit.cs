using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ai;
using Ai.Eqs;

public class DestroyOnGroundHit : MonoBehaviour
{
    public void OnGroundHit(float x)
    {
        Destroy(gameObject);
    }
}

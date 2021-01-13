using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public Vector3 force;

    private void Update()
    {
        transform.position += force * Time.deltaTime;
    }
}

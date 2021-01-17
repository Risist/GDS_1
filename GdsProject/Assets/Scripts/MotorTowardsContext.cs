using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ai;
using Ai.Eqs;

public class MotorTowardsContext : MonoBehaviour
{
    public float speed;
    public Context pointContext;

    private void Update()
    {
        Debug.Assert(pointContext is IPointContext);

        transform.position = Vector3.MoveTowards(transform.position, ((IPointContext)pointContext).GetPoint(), speed * Time.deltaTime);
    }
}

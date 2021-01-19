using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ai;
using Ai.Eqs;

public class MotorTowardsContext : MonoBehaviour
{
    public float speed;
    public Context pointContext;
    public bool cache;

    Vector3 target;
    private void Start()
    {
        if (cache)
            target = ((IPointContext)pointContext).GetPoint();
    }

    private void Update()
    {
        Debug.Assert(pointContext is IPointContext);

        if (!cache)
            target = ((IPointContext)pointContext).GetPoint();

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}

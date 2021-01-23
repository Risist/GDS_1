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
    public bool cameraSpace;

    Vector3 target;
    private void Start()
    {
        if (cache)
        {
            target = ((IPointContext)pointContext).GetPoint();
            if (cameraSpace)
                target = Camera.main.transform.InverseTransformPoint(target);
        }
    }

    private void Update()
    {
        Debug.Assert(pointContext is IPointContext);

        if (!cache)
        {
            target = ((IPointContext)pointContext).GetPoint();
            if (cameraSpace)
                target = Camera.main.transform.InverseTransformPoint(target);
        }

        if (cameraSpace)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
            if (Mathf.Approximately(transform.localPosition.x, target.x) &&
                Mathf.Approximately(transform.localPosition.y, target.y) &&
                Mathf.Approximately(transform.localPosition.z, target.z))
                SendMessage("OnArriveToContext", ((IPointContext)pointContext).GetPoint(), SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Mathf.Approximately(transform.position.x, target.x) &&
                Mathf.Approximately(transform.position.y, target.y) &&
                Mathf.Approximately(transform.position.z, target.z))
                SendMessage("OnArriveToContext", target, SendMessageOptions.DontRequireReceiver);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoController : MonoBehaviour
{
    public float movementSpeed;

    public void SetMovementTarget(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }
    Vector3 _targetPosition;

    void Update()
    {
        Vector3 finalPosition = Vector3.MoveTowards(transform.position, _targetPosition, movementSpeed * Time.deltaTime);
        finalPosition.z = transform.position.z;
        transform.position = finalPosition;
    }
}

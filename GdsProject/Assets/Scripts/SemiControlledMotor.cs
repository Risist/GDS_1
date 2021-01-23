using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiControlledMotor : MonoBehaviour
{
    public Vector3 speed;

    Transform _movementDirector;
    Vector3 _lastParentPosition;

    public void OnBulletSpawn(GameObject movementDirector)
    {
        _lastParentPosition = movementDirector.transform.position;
        _movementDirector = movementDirector.transform;
    }

    private void Update()
    {
        if (!_movementDirector)
            return;

        Vector3 currentParentPosition = _movementDirector.transform.position;

        //Mathf.Sign()
        Vector3 diff = currentParentPosition - _lastParentPosition;
        Vector3 diffSpeed = new Vector3(
            Mathf.Sign(diff.x) * speed.x,
            Mathf.Sign(diff.y) * speed.y,
            Mathf.Sign(diff.z) * speed.z
            );

        transform.position += diffSpeed * Time.deltaTime;
        _lastParentPosition = currentParentPosition;
    }

}

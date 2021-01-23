using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxa : MonoBehaviour
{
    public float cameraPositionInfluence;
    Transform _cameraTransform;
    Vector3 _initialPosition;
    Vector3 _initialCameraPosition;
    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _initialPosition = transform.position;
        _initialCameraPosition = _cameraTransform.position;
        UpdatePosition();
    }

    void UpdatePosition()
    {
        transform.position = _initialPosition +
            Vector3.right * (_cameraTransform.position.x - _initialCameraPosition.x) * cameraPositionInfluence;
    }
    private void Update()
    {
        UpdatePosition();
    }
}

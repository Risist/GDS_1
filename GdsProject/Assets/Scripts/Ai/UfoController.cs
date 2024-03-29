﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoController : MonoBehaviour
{
    public float movementSpeed;
    float _movementSpeed;

    BulletThrower _bulletThrower; 
    Vector3 _targetPosition;

    #region Functions

    public GameObject ShootBullet()
    {
        return _bulletThrower.ProceedShoot();
    }

    public void SetMovementTarget(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        _movementSpeed = movementSpeed;
    }
    public void SetMovementTarget(Vector3 targetPosition, float movementSpeed)
    {
        _targetPosition = targetPosition;
        _movementSpeed = movementSpeed;
    }

    #endregion

    void Start()
    {
        _bulletThrower = GetComponentInChildren<BulletThrower>();
    }
    void Update()
    {
        Vector3 finalPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, _movementSpeed * Time.deltaTime);
        finalPosition.z = transform.localPosition.z;
        transform.localPosition = finalPosition;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ai;
using Ai.Eqs;

public class MotorExplosiveBullet : MonoBehaviour
{
    public Context targetContext;
    public string heightObjectTag;
    public float speed;
    public float explosionCreationOffset;
    [Header("FreeArea")]
    public float requiredFreeArea;
    public float freeAreaTestOffset;


    public GameObject holePrefab;
    public GameObject[] spawnedObjectsOnExplosion;
    public Vector3 holePrefabOffset;

    Vector3 _target;

    void OnGroundHit(float x)
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y = _target.y + explosionCreationOffset;

        Instantiate(holePrefab, spawnPos, Quaternion.identity);
        foreach (var item in spawnedObjectsOnExplosion)
        {
            Instantiate(item);
        }
        Destroy(gameObject);
    }

    void RefreshTarget()
    {
        _target = ((IPointContext)targetContext).GetPoint();

        var heightObject = GameObject.FindGameObjectWithTag(heightObjectTag)?.transform;
        _target.y = heightObject.position.y - explosionCreationOffset;
        _target = ObstacleMarker.FindClosestFreePosition(_target, requiredFreeArea, freeAreaTestOffset);
    }

    void Update()
    {
        RefreshTarget();
        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
    }
}
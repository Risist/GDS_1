﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CheckpointRecorder : MonoBehaviour
{
    public string activatingTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(activatingTag))
            return;

        CheckpointManager.instance.RecordCheckpoint();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(activatingTag))
            return;

        CheckpointManager.instance.RecordCheckpoint();
    }
}
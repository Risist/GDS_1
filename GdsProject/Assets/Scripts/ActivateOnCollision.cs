using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnCollision : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public string activatingTag;

    private void Start()
    {
        foreach (var it in objectsToActivate)
        {
            it.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(activatingTag))
            return;

        foreach(var it in objectsToActivate)
        {
            it.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(activatingTag))
            return;

        foreach (var it in objectsToActivate)
        {
            it.SetActive(true);
        }
    }
}

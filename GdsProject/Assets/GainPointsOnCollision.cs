using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainPointsOnCollision : MonoBehaviour
{
    public string playerTag = "Player";
    public int points = 50;
    bool gained;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gained)
            return;

        if (!collision.CompareTag(playerTag))
            return;

        gained = true;
        PointManager.instance.GainPoints(points);
    }
}

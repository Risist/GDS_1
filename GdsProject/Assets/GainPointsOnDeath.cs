using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainPointsOnDeath : MonoBehaviour
{
    public int points = 50;
    bool gained;

    private void Start()
    {
        var hp = GetComponent<HealthController>();
        if(hp)
        {

            hp.onDeathCallback += (data) =>
            {
                if (!gained)
                {
                    gained = true;
                    PointManager.instance.GainPoints(points);
                }
            };
        }
    }
}

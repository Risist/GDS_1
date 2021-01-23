using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDealDamage : MonoBehaviour
{
    public GameObject toSpawn;
    bool spawned;
    
    void OnDamageDealed()
    {
        if (spawned)
            return;
        spawned = true;

        toSpawn.SetActive(true);
        Instantiate(toSpawn, transform.position, transform.rotation);
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RespawnAfterDeath : MonoBehaviour
{
    public float respawnDelay;

    private void Start()
    {
        var healthController = GetComponentInParent<HealthController>();
        Debug.Assert(healthController);
        healthController.destroyOnDeath = false;

        healthController.onDeathCallback += (DamageData data) =>
        {
            healthController.gameObject.SetActive(false);
            CheckpointManager.instance.StartCoroutine(Restart(healthController));
        };
    }

    IEnumerator Restart(HealthController hp)
    {
        yield return new WaitForSeconds(respawnDelay);
        hp.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        CheckpointManager.instance.ResetToLastCheckpoint();
    }
}

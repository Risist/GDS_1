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

            if (LivesManager.instance.LooseLive())
            {
                CheckpointManager.instance.StartCoroutine(Restart(healthController));
            }else
            {
                // TODO run game over ui and after short delay move towards main menu
                // just before call LivesManager.instance.ResetLives();
            }
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

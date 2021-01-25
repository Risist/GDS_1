using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnDealDamage : MonoBehaviour
{
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

        var hp = GetComponent<HealthController>();
        if (hp)
            hp.Kill(new DamageData());
    }
    void OnDamageDealed()
    {
        StartCoroutine(Wait());
    }
}

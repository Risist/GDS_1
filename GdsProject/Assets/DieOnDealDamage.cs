using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnDealDamage : MonoBehaviour
{
    void OnDamageDealed()
    {
        var hp = GetComponent<HealthController>();
        if (hp)
            hp.Kill(new DamageData());
    }
}

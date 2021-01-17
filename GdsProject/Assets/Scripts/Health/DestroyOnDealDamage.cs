using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDealDamage : MonoBehaviour
{
    void OnDamageDealed()
    {
        Destroy(gameObject,0.1f);
    }
}

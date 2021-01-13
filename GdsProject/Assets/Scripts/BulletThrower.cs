using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletThrower : MonoBehaviour
{
    public GameObject bullet;
    public Timer shootRate;
    public bool parent;

    void Start()
    {
        shootRate.Restart();
    }

    public void ProceedShoot()
    {
        if(shootRate.IsReadyRestart())
        {
            var obj = Instantiate(bullet, transform.position, transform.rotation);
            if (parent)
                obj.transform.parent = transform;
        }
    }
}

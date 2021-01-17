using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletThrower : MonoBehaviour
{
    public GameObject bullet;
    public Timer shootRate;
    public bool parent;
    new Camera camera;

    void Start()
    {
        shootRate.Restart();
        camera = Camera.main;
    }

    public GameObject ProceedShoot()
    {
        if(shootRate.IsReadyRestart())
        {
            var obj = Instantiate(bullet, transform.position, transform.rotation);
            if (parent)
                obj.transform.parent = camera.transform;
            return obj;
        }

        return null;
    }
}

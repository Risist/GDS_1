using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public BulletThrower[] throwers;
    PlayerInputHolder _inputHolder;

    private void Awake()
    {
        _inputHolder = GetComponent<PlayerInputHolder>();
    }

    private void Update()
    {
        if(_inputHolder.shootInput)
        {
            foreach (var it in throwers)
                it.ProceedShoot();
        }
    }

}

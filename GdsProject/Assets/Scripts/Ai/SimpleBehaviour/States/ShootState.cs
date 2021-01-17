using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai
{
    [CreateAssetMenu(fileName = "New ShootState", menuName = "Ris/Ai/SimpleState/Shoot", order = 0)]
    public class ShootState : UfoState
    {
        public override void OnUpdate()
        {
            base.OnUpdate();
            var bullet = _ufoController.ShootBullet();
            bullet.BroadcastMessage("OnBulletSpawn", controller.gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }
}

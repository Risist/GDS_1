﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai
{
    [CreateAssetMenu(fileName = "New MoveToState", menuName = "Ris/Ai/SimpleState/MoveTo", order = 0)]
    public class MoveToState : UfoState
    {
        public Vector3 offsetFromTarget;
        public bool bOverrideSpeed;
        public float speed;
        public override void OnUpdate()
        {
            base.OnUpdate();
            if(bOverrideSpeed)
                _ufoController.SetMovementTarget(offsetFromTarget, speed);
            else
                _ufoController.SetMovementTarget(offsetFromTarget);

        }
    }
}

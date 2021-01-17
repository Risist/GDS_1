using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Ai.Eqs;

namespace Ai
{
    [CreateAssetMenu(fileName = "New MoveToContextState", menuName = "Ris/Ai/SimpleState/MoveToContext", order = 0)]
    public class MoveToContextState : UfoState
    {
        public Context target;
        public bool cachePosition;

        Vector3 targetPosition;

        public override void OnBegin()
        {
            base.OnBegin();
            Debug.Assert(target is IPointContext);
            if (cachePosition)
                targetPosition = ((IPointContext)target).GetPoint();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if(!cachePosition)
                targetPosition = ((IPointContext)target).GetPoint();

            _ufoController.SetMovementTarget(targetPosition);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai.Eqs
{
    public abstract class ObjectContext : ConstantContext, IObjectContext
    {
        public abstract GameObject GetGameObject();

        Vector3 lastObjectPosition;
        public override Vector3 GetPoint()
        {
            var obj = GetGameObject();
            if (obj)
                lastObjectPosition = obj.transform.position;
            return lastObjectPosition + base.GetPoint();
        }
    }
}

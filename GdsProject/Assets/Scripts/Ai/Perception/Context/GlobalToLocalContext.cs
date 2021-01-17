using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai.Eqs
{
    [CreateAssetMenu(fileName = "New GlobalToLocalContext", menuName = "Ris/Ai/Context/GlobalToLocalContext")]
    public class GlobalToLocalContext : Context, IPointContext
    {
        public ObjectContext localSpaceContext;
        public Context transformedContext;

        Vector3 lastPosition;
        public Vector3 GetPoint()
        {
            Debug.Assert(transformedContext is IPointContext);

            var obj = localSpaceContext.GetGameObject();

            if(obj)
            {
                lastPosition = obj.transform.InverseTransformPoint(((IPointContext)transformedContext).GetPoint());
            }

            return lastPosition;
        }
    }
}

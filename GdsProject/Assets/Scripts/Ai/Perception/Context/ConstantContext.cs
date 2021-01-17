using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai.Eqs
{
    [CreateAssetMenu(fileName = "New ConstantContext", menuName = "Ris/Ai/Context/ConstantContext")]
    public class ConstantContext : Context, IPointContext
    {
        public Vector3 offset;

        public virtual Vector3 GetPoint()
        {
            return offset;
        }
    }
}

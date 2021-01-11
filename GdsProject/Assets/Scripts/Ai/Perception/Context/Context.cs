using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai.Eqs
{
    public abstract class Context : ScriptableObject
    {
        public abstract Vector3 GetPoint();
    }
}

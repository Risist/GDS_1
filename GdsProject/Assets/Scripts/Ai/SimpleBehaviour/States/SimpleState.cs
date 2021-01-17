using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai
{
    // simplified version of state machine designed for ordered execution
    // actually the system will work more like a list - what fits the project more
    public abstract class SimpleState : ScriptableObject
    {
        [HideInInspector]
        public SimpleBehaviourController controller;

        public virtual void OnBegin() { }
        public virtual void OnEnd() { }
        public virtual void OnUpdate() { }
        public abstract bool ShallReturn();
    }
}

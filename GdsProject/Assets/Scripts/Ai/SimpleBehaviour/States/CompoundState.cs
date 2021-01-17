using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai
{

    [CreateAssetMenu(fileName = "New CompoundState", menuName = "Ris/Ai/SimpleState/CompoundState", order = 0)]
    public class CompoundState : SimpleState
    {
        public SimpleState[] states;

        public override void OnBegin()
        {
            base.OnBegin();
            foreach (var it in states)
                it.OnBegin();
        }

        public override void OnEnd()
        {
            base.OnEnd();
            foreach (var it in states)
                it.OnEnd();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            foreach (var it in states)
                it.OnUpdate();
        }

        public override bool ShallReturn()
        {
            foreach (var it in states)
                if (!it.ShallReturn())
                    return false;
            return true;
        }
    }
}

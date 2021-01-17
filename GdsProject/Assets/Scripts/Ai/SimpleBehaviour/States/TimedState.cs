using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai
{
    [CreateAssetMenu(fileName = "New TimedState", menuName = "Ris/Ai/SimpleState/TimedState", order = 0)]
    public class TimedState : SimpleState
    {
        public Timer maxExecutionTime;

        public override void OnBegin()
        {
            base.OnBegin();
            maxExecutionTime.Restart();
        }
        public override bool ShallReturn()
        {
            return maxExecutionTime.IsReady();
        }
    }
}

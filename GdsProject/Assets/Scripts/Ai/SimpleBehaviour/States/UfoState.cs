using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai
{
    public abstract class UfoState : TimedState
    {
        protected UfoController _ufoController;

        public override void OnBegin()
        {
            base.OnBegin();
            if (!controller)
                return;
            _ufoController = controller.GetComponent<UfoController>();
        }
    }
}

using UnityEngine;

namespace Ai
{
    [CreateAssetMenu(fileName = "MoveTowardsBehaviourPack", menuName = "Ris/Ai/BehaviourPack/MoveTowards", order = 0)]
    public class BehaviourPackMoveTowards : BehaviourPack
    {
        public Eqs.Context targetContext;
        public Vector3 offsetFromTarget;
        public float inStateTime;

        protected override void DefineBehaviours_Impl()
        {
            var stateMachine = controller.stateMachine;
            var ufoController = controller.GetComponent<UfoController>();
            var transform = controller.transform;
            var idle = stateMachine.AddNewStateAsCurrent();

            Timer stateTimer = new Timer(inStateTime);

            idle
                .AddShallReturn(stateTimer.IsReady)
                .AddOnUpdate(() =>
                {
                    ufoController.SetMovementTarget(offsetFromTarget);
                });

        }
    }
}


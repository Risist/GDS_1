using UnityEngine;

namespace Ai
{
    [CreateAssetMenu(fileName = "TestBehaviourPack", menuName = "Ris/Ai/BehaviourPack/Test", order = 0)]
    public class BehaviourPackTest : BehaviourPack
    {
        public Eqs.Context targetContext;
        public Vector3 offsetFromTarget;
        [Space]
        public Vector3 offsetFromTarget_state1;
        public Vector3 offsetFromTarget_state2;
        public Vector3 offsetFromTarget_state3;
        public Vector3 offsetFromTarget_state4;


        protected override void DefineBehaviours_Impl()
        {
            var stateMachine = controller.stateMachine;
            var ufoController = controller.GetComponent<UfoController>();

            var idle = stateMachine.AddNewStateAsCurrent();

            idle.AddOnUpdate(() =>
            {
                Vector3 contextPoint = targetContext.GetPoint();
                GroundTileManager.instance.GetWorldHeight(contextPoint.x, out contextPoint.y );

                ufoController.SetMovementTarget(contextPoint + offsetFromTarget);
            });

        }
    }
}
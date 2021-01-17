using UnityEngine;

namespace Ai
{
    [CreateAssetMenu(fileName = "TestBehaviourPack", menuName = "Ris/Ai/BehaviourPack/Test", order = 0)]
    public class BehaviourPackTest : BehaviourPack
    {
        public Eqs.Context targetContext;
        public Vector3 offsetFromTarget;
        public Vector2 targetRandomParam = new Vector2(7,1);
        public float closeDistance = 0.1f;


        protected override void DefineBehaviours_Impl()
        {
            var stateMachine = controller.stateMachine;
            var ufoController = controller.GetComponent<UfoController>();
            var transform = controller.transform;

            var idle = stateMachine.AddNewStateAsCurrent();

            Vector3 movementTargetOffset = Vector3.zero;

            /*idle
                .AddOnBegin(() => movementTargetOffset = new Vector3(
                    (Random.value *2-1) * targetRandomParam.x, 
                    (Random.value *2-1) * targetRandomParam.y))
                .AddShallReturn( () =>
                {
                    Vector3 contextPoint = targetContext.GetPoint();
                    GroundTileManager.instance.GetWorldHeight(contextPoint.x, out contextPoint.y);
                    Vector3 target = contextPoint + offsetFromTarget + movementTargetOffset;

                    Vector3 diff = (transform.position - target);
                    diff.z = 0;
                    return diff.sqrMagnitude < closeDistance * closeDistance;

                })
                .AddOnUpdate(() =>
                {
                    Vector3 contextPoint = targetContext.GetPoint();
                    GroundTileManager.instance.GetWorldHeight(contextPoint.x, out contextPoint.y );

                    Vector3 target = contextPoint + offsetFromTarget + movementTargetOffset;
                    target.z = transform.position.z;
                    ufoController.SetMovementTarget(target);
                });*/

        }

        
    }
}
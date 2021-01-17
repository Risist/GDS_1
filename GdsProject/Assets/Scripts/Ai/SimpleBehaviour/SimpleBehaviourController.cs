using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai
{
    // executes states in order
    public class SimpleBehaviourController : MonoBehaviour
    {
        public enum EFinishAction
        {
            EDestroy,
            EDisable,
            EStayInLastState,
            ELoop
        }
        public SimpleState[] stateList;
        public EFinishAction finishAction;

        [Header("Working params")]
        [SerializeField] int currentStateIndex = 0;

        public SimpleState currentState => RangedInt.InRange(currentStateIndex, 0, stateList.Length) ?
            stateList[currentStateIndex] :
            null;

        private void Start()
        {
            foreach(var it in stateList)
            {
                it.controller = this;
            }
            Debug.Assert(currentState);
            currentState.OnBegin();
        }

        private void Update()
        {
            currentState.OnUpdate();
            if(currentState.ShallReturn())
            {
                currentState.OnEnd();
                ++currentStateIndex;

                if(CheckFinishAction())
                {
                    currentState.OnBegin();
                }
            }
        }

        // returns if current action should be initialized
        // TODO: change name for better one
        bool CheckFinishAction()
        {
            if (currentStateIndex >= stateList.Length)
            {
                switch (finishAction)
                {
                    case EFinishAction.EDestroy:
                        Destroy(gameObject);
                        return false;
                    case EFinishAction.EDisable:
                        enabled = false;
                        return false;
                    case EFinishAction.EStayInLastState:
                        currentStateIndex = stateList.Length;
                        return false;
                    case EFinishAction.ELoop:
                        currentStateIndex = 0;
                        currentState.OnBegin();
                        return true;
                }
            }
            return true;
        }
    }

    


}

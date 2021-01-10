using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai
{
    public abstract class BehaviourPack : ScriptableObject
    {
        public void DefineBehaviours(BehaviourController controller)
        {
            this.controller = controller;
            DefineBehaviours_Impl();
        }
        protected abstract void DefineBehaviours_Impl();

        protected BehaviourController controller;

        ////////// Utility
        ///

        public const string enemyId = nameof(enemyId);
        public const string allyId = nameof(allyId);
        public const string neutralId = nameof(neutralId);
        public const string noiseId = nameof(noiseId);
        public const string painId = nameof(painId);
        public const string touchId = nameof(touchId);

    }
}

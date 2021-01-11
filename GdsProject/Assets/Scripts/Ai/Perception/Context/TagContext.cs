using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai.Eqs
{
    [CreateAssetMenu(fileName = "New TagContext", menuName = "Ris/Ai/Context/TagContext")]
    public class TagContext : Context
    {
        public string tagName;
        Transform playerTransform;
        public override Vector3 GetPoint()
        {
            if (playerTransform == null)
            {
                playerTransform = GameObject.FindGameObjectWithTag(tagName).transform;
            }
            return playerTransform.transform.position;
        }
    }
}

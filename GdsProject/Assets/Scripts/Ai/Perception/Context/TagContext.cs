using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai.Eqs
{
    [CreateAssetMenu(fileName = "New TagContext", menuName = "Ris/Ai/Context/TagContext")]
    public class TagContext : ObjectContext
    {
        public string tagName;
        GameObject tagObject;

        public override GameObject GetGameObject()
        {
            if (tagObject == null)
            {
                tagObject = GameObject.FindGameObjectWithTag(tagName);
            }
            return tagObject;
        }

    }
}

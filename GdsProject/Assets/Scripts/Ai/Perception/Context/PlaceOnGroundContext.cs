using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ai.Eqs
{
    [CreateAssetMenu(fileName = "New PlaceOnGroundContext", menuName = "Ris/Ai/Context/PlaceOnGroundContext")]
    public class PlaceOnGroundContext : Context, IPointContext
    {
        public Context contextToConvert;
        public Vector3 offset;
        public Vector3 GetPoint()
        {
            Vector3 pos = ((IPointContext)contextToConvert).GetPoint();
            if (GroundTileManager.instance.GetWorldHeight_WorldCoords(pos.x, out float height))
                pos.y = height;

            return pos + offset;
        }
    }
}

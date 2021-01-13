using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GroundTileManager : MonoSingleton<GroundTileManager>
{
    public GroundTileInstance[] groundtiles;

    public bool GetTopPosition(float xTilePosition, out Vector3 position)
    {
        float begin;
        var tile = GetTileAtTexturePosition(xTilePosition, out begin);

        float xPositionOnTexture = xTilePosition - begin;


        if (tile == null || !tile.IsOnTexture(xPositionOnTexture))
        {
            position = Vector3.zero;
            // wrong position
            return false;
        }

        position = tile.ComputeWorldPosition(xPositionOnTexture);

        return true;
    }
    public bool GetWorldHeight(float xTilePosition, out float height)
    {
        float begin;
        var tile = GetTileAtTexturePosition(xTilePosition, out begin);

        float xPositionOnTexture = xTilePosition - begin;


        if (tile == null || !tile.IsOnTexture(xPositionOnTexture))
        {
            height = 0;
            // wrong position
            return false;
        }

        height = tile.ComputeWorldPosition(xPositionOnTexture).y;

        return true;
    }

    public void CutHoleInGround(Vector3 worldPosition, float worldRadius)
    {
        foreach (var it in groundtiles)
        {
            it.CutHoleInGround_WorldCoord(worldPosition, worldRadius);
        }
    }

    public GroundTileInstance GetTileAtTexturePosition(float xTileTexturePosition, out float begin)
    {
        begin = 0;
        foreach(var it in groundtiles)
        {
            float end = begin + it.width;
            if (xTileTexturePosition > begin && xTileTexturePosition <= end)
            {
                return it;
            }
            begin = end;
        }
        return null;
    }

    public GroundTileInstance GetTileAtWorldPosition(float xTileWorldPosition, out float begin, out float xTileTexturePosition)
    {
        begin = 0;
        xTileTexturePosition = 0;

        foreach (var it in groundtiles)
        {
            var pos = it.ComputeTexturePosition(Vector3.right * xTileWorldPosition);
            
            float end = begin + it.width;
            if (pos.x > begin && pos.x <= end)
            {
                xTileTexturePosition = pos.x;
                return it;
            }
            begin = end;
        }
        return null;
    }

    

    [ContextMenu("SetupTilePositions")]
    void EditorFunction_SetupTilePositions()
    {
        Vector3 position = transform.position;
        foreach(var it in groundtiles)
        {
            float worldSpaceWidth = (float)it.width / (float)it.tileDefinition.pixelsPerUnit;
            position.x += worldSpaceWidth * 0.5f;
            it.transform.position = position;
            position.x += worldSpaceWidth * 0.5f;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GroundTileInstance : MonoBehaviour
{
    public GroundTile tileDefinition;
    public bool reversed = false;

    public int[] topHeights
    {
        get
        {
            if (_topHeights == null)
            {
                _topHeights = (int[])tileDefinition.topHeights.Clone();
            }
            return _topHeights;
        }
    }
    [NonSerialized]
    int[] _topHeights;

    bool[] _modified; 
    public bool[] modified
    {
        get
        {
            if (_modified == null)
            {
                _modified = new bool[topHeights.Length];
            }
            return _modified;
        }
    }

    public void Awake()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tileDefinition.sprite;
    }

    public int width  => tileDefinition.width;
    public int height => tileDefinition.height;

    public Vector3 ComputeWorldPosition(Vector2Int texturePosition)
    {
        return tileDefinition.ComputeWorldPosition(texturePosition, transform);
    }
    public Vector3 ComputeWorldPosition(float xPositionOnTexture)
    {
        float heightId = reversed ? width - 1 - xPositionOnTexture : xPositionOnTexture;
        
        return tileDefinition.ComputeWorldPosition(new Vector2Int(
                (int)xPositionOnTexture,
                topHeights[(int)heightId]),

            transform
        );
    }

    public Vector2Int ComputeTexturePosition(Vector3 worldPosition)
    {
        return tileDefinition.ComputeTexturePosition(worldPosition, transform);
    }

    public bool IsOnTexture(float xPosition)
    {
        return xPosition >= 0 && xPosition < width;
    }

    public void CutHoleInGround_TextureCoord(Vector2Int texturePosition, int textureRadius)
    {
        for(int i = 0; i < width; ++i)
        {
            int heightId = reversed ? width - 1 - i : i;

            if (heightId < texturePosition.x - textureRadius || heightId > texturePosition.x + textureRadius)
                continue;

            int xOffset = Mathf.Abs(texturePosition.x - heightId);
            float cosinus = (float)xOffset / (float)textureRadius;
            float sinus = Mathf.Sqrt( 1 - cosinus * cosinus);
            int cutHeight = texturePosition.y - (int)(sinus * textureRadius);

            topHeights[i] = Mathf.Min(topHeights[i], cutHeight);
            modified[heightId] = true;
        }
    }
    public void CutHoleInGround_WorldCoord(Vector3 worldPosition, float radius)
    {
        Vector3 localPosition = worldPosition - transform.position;
        Vector2Int texturePosition = tileDefinition.ComputeTexturePosition(localPosition);

        Debug.DrawRay(tileDefinition.ComputeWorldPosition(texturePosition, transform), Vector2.up, Color.green, 40.0f);
        int textureRadius = (int)(radius * tileDefinition.pixelsPerUnit);
        CutHoleInGround_TextureCoord(texturePosition, textureRadius);
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < width; ++i)
        {
            var pos = ComputeWorldPosition(i);

            Gizmos.color = modified[i] ? Color.red : Color.blue;

            Gizmos.DrawCube(pos, Vector3.one * 0.05f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGroundTile", menuName ="Ris/GroundTile")]
[DefaultExecutionOrder(999999999)]
public class GroundTile : ScriptableObject
{
    public int pixelsPerUnit = 100;

    public Sprite sprite;
    public Color alphaColor = new Color(0,0,0,0);

    public int width  => _texture.width;
    public int height => _texture.height;

    public int[] topHeights
    {
        get
        {
            if(_topHeights == null)
            {
                _topHeights = ComputeHeights();
            }
            return _topHeights;
        }
    }
    [System.NonSerialized]
    int[] _topHeights;


    Texture2D _texture => sprite.texture;

    public Vector3 ComputeWorldPosition(Vector2Int texturePosition)
    {
        Vector3 worldTexturePosition = new Vector3(texturePosition.x, texturePosition.y) / pixelsPerUnit;
        // move from center to left bottom corner
        worldTexturePosition -= new Vector3(_texture.width, _texture.height) * 0.5f / pixelsPerUnit;
        return worldTexturePosition;
    }
    public Vector3 ComputeWorldPosition(Vector2Int texturePosition, Transform referneceTransform)
    {
        Vector3 worldTexturePosition = ComputeWorldPosition(texturePosition);
        return referneceTransform.TransformPoint(worldTexturePosition);
    }
    

    public Vector2Int ComputeTexturePosition(Vector3 worldPosition)
    {
        Vector3 worldTexturePosition = new Vector3(worldPosition.x, worldPosition.y) * pixelsPerUnit;
        // move from center to left bottom corner
        worldTexturePosition += new Vector3(_texture.width, _texture.height) * 0.5f;
        return new Vector2Int((int)worldTexturePosition.x, (int)worldTexturePosition.y);
    }
    public Vector2Int ComputeTexturePosition(Vector3 worldPosition, Transform referneceTransform)
    {
        return ComputeTexturePosition(referneceTransform.InverseTransformPoint(worldPosition));
    }


    public bool IsOnTexture(float xPosition)
    {
        return xPosition >= 0 && xPosition < width;
    }

    int[] ComputeHeights()
    {
        int[] height = new int[_texture.width];

        for (int x = 0; x < _texture.width; ++x)
        {
            var pixels = _texture.GetPixels(x, 0, 1, _texture.height);
            var top = 0;
            for (int y = _texture.height - 1; y >= 0; --y)
            {
                if (pixels[y] == alphaColor || pixels[y].a == 0)
                    top = y;
                else
                    break;
            }

            height[x] = top;
        }

        return height; 
    }
}

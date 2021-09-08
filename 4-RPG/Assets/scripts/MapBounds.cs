using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Sets and applies bounds for map camera
public class MapBounds : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private float xMax, xMin, yMin, yMax;
    [SerializeField]
    Camera mapCam;

    void Start()
    {
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);
        SetMapLimit(minTile, maxTile);
    }

    private void SetMapLimit(Vector3 minTile, Vector3 maxTile)
    {
        float fHeight = 2f * mapCam.orthographicSize;
        float fWidth = fHeight * mapCam.aspect;

        xMin = minTile.x + fWidth / 2;
        xMax = maxTile.x - fWidth / 2;
        yMin = minTile.y + fHeight / 2;
        yMax = maxTile.y - fHeight / 2;
    }
}

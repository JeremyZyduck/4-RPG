#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#endregion
/*<SUMMARY>
 *Sets and applies bounds to camera based on tilemap.
<USE>
 *Map Camera.
</USE>
</SUMMARY>*/
public class MapBounds : MonoBehaviour
{
    #region TODO
    #endregion
    #region MAP BOUNDS
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private float xMax, xMin, yMin, yMax;
    [SerializeField]
    Camera mapCam;
    private void SetMapLimit(Vector3 minTile, Vector3 maxTile)
    {
        float fHeight = 2f * mapCam.orthographicSize;
        float fWidth = fHeight * mapCam.aspect;

        xMin = minTile.x + fWidth / 2;
        xMax = maxTile.x - fWidth / 2;
        yMin = minTile.y + fHeight / 2;
        yMax = maxTile.y - fHeight / 2;
    }
    #endregion
    #region DEFAULT
    void Start()
    {
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);
        SetMapLimit(minTile, maxTile);
    }
    #endregion
}

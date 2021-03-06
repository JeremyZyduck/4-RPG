#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#endregion
/*<SUMMARY>
 *Follows player and uses clamps to prevent the camera from going off the edge of the tilemap
<USE>
 *Main Camera
</USE>
</SUMMARY>*/
public class CameraFollow : MonoBehaviour
{
    #region TODO
    //Give a buffer before the camera begins to move
    //Investigate cinamachine
    #endregion

    #region MAP PARAMS
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float fSmoothTime;
    [SerializeField]
    private float xMax, xMin, yMin, yMax;
    [SerializeField]
    private Tilemap tilemap;

    public float targetDistance = 0.5f;
    private void SetMapLimit(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;
        float fHeight = 2f * cam.orthographicSize;
        float fWidth = fHeight * cam.aspect;

        xMin = minTile.x + fWidth / 2;
        xMax = maxTile.x - fWidth / 2;
        yMin = minTile.y + fHeight / 2;
        yMax = maxTile.y - fHeight / 2;
    }
    #endregion

    #region DEFAULT
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);
        SetMapLimit(minTile, maxTile);
    }

    public void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(target.position.x, xMin, xMax),
            Mathf.Clamp(target.position.y, yMin, yMax), -10);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * fSmoothTime);
    }
    #endregion
}

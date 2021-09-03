using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBounds : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float xMax, xMin, yMin, yMax;

    [SerializeField]
    Camera mapCam;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        SetMapLimit(minTile, maxTile);
        target = mapCam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(target.position.x, xMin, xMax),
            Mathf.Clamp(target.position.y, yMin, yMax),
            -10);

        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * 1F);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Follows player and uses clamps to prevent the camera from going off the edge of the tilemap
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float fSmoothTime;

    [SerializeField]
    private float xMax, xMin, yMin, yMax;

    [SerializeField]
    private Tilemap tilemap;

    public float targetDistance = 0.5f;

    [SerializeField]
    private PlayerController character;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        character = target.GetComponent<PlayerController>();
        
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        SetMapLimit(minTile, maxTile);
        character.SetLimits(minTile, maxTile);
    }

    public void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(target.position.x, xMin, xMax), 
            Mathf.Clamp(target.position.y, yMin, yMax), 
            -10);

        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * fSmoothTime);

    }

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
}

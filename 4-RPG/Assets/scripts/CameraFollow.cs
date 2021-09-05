using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        character = target.GetComponent<PlayerController>();
        
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        SetMapLimit(minTile, maxTile);
        character.SetLimits(minTile, maxTile);
    }

    private void Update()
    {
    }

    // Update is called once per frame
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

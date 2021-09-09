#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#endregion

public class CursorMove : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField] 
    private Tilemap debugmap;
    [SerializeField]
    private Tile hoverTile;
    private Vector3Int previousMousePos = new Vector3Int();

    // Update is called once per frame
    void Update()
    {
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            debugmap.SetTile(previousMousePos, null); // Remove old hoverTile
            debugmap.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }
    }

    public Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}


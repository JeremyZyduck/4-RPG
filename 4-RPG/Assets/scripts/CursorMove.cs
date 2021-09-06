using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorMove : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField] 
    private Tilemap debugmap;
    [SerializeField]
    private Tile hoverTile;
    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Vector2 CurmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(CurmousePos.x, CurmousePos.y);
            if (Input.GetButtonDown("Fire1"))
            {
                //TODO: CHANGE COLOR
            }
            if (Input.GetButtonDown("Fire2"))
            {
                //TODO: CHANGE COLOR
            }
        }
        catch
        { 
        //TODO: DISABLE CURSOR
        }
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


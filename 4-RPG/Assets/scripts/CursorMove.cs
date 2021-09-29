#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#endregion
/*<SUMMARY>
 *Selects and highlights the current tile being moused over
<USE>
 *Child of Player object
</USE>
</SUMMARY>*/
public class CursorMove : MonoBehaviour
{
    #region TODO
    #endregion

    #region TILE
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Tilemap debugmap;
    [SerializeField]
    private Tile hoverTile;
    #endregion
    #region MOUSE
    private Vector3Int previousMousePos = new Vector3Int();
    public Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
    #endregion
    #region DEFAULT
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
    #endregion
}


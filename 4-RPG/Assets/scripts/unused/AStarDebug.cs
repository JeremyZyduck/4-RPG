using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AStarDebug : MonoBehaviour
{
    private static AStarDebug instance;
    public static AStarDebug thisInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AStarDebug>();
            }
            return instance;
        }
    }

    [SerializeField]
    private Grid grid;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile tile;

    [SerializeField]
    private Color openColor, closedColor, pathColor, currentColor;

    private List<GameObject> debugObjects = new List<GameObject>();

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject debugTextPrefab;
    [SerializeField]
    private Tile sTile;
    [SerializeField]
    private Tile eTile;

    public void CreateTiles(HashSet<Node> openList, HashSet<Node> closedList, Dictionary<Vector3Int, Node> allNodes, Vector3Int start, Vector3Int goal, Stack<Vector3Int> path = null)
    {

        foreach (GameObject go in debugObjects)
        {
            Destroy(go);
        }

        foreach (Node item in openList)
        {
            ColorTile(item.Position, openColor);
        }

        foreach (var item in closedList)
        {
            ColorTile(item.Position, closedColor);
        }

        if (path != null)
        {
            foreach (Vector3Int positem in path)
            {
                if (positem != start && positem != goal)
                {
                    ColorTile(positem, pathColor);
                }

            }
        }

        tilemap.SetTile(start, sTile);
        tilemap.SetTile(goal, eTile);
        //ColorTile(goal, goalColor);

        foreach (KeyValuePair<Vector3Int, Node> item in allNodes)
        {
            if (item.Value.Parent != null)
            {
                if (item.Key != goal)
                {
                    GameObject go = Instantiate(debugTextPrefab, canvas.transform);
                    go.transform.position = grid.CellToWorld(item.Key);
                    debugObjects.Add(go);
                    GenerateDebugText(item.Value, go.GetComponent<DebugText>());
                }
            }

        }
    }

    private void GenerateDebugText(Node node, DebugText debugText)
    {
        debugText.P.text = $"P:{node.Position.x},{node.Position.y}";
        debugText.F.text = $"F:{node.F}";
        debugText.G.text = $"G:{node.G}";
        debugText.H.text = $"H:{node.H}";
        Vector3Int direction = node.Parent.Position - node.Position;
        debugText.curArrow.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

    public void ColorTile(Vector3Int pos, Color col)
    {
        tilemap.SetTile(pos, tile);
        tilemap.SetTileFlags(pos, TileFlags.None);
        tilemap.SetColor(pos, col);
    }

    public void Reset(Dictionary<Vector3Int, Node> allNodes)
    {
        foreach (GameObject item in debugObjects)
        {
            Destroy(item);
        }
        debugObjects.Clear();
        foreach (Vector3Int item in allNodes.Keys)
        {
            tilemap.SetTile(item, null);
        }
        tilemap.ClearAllTiles();
    }
}

#region USING
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
#endregion
public enum TileType {START, GOAL, WALKABLE, NONWALKABLE, PATH }

/*<SUMMARY>
 *Implementation of the A* algorithm
<USE>
 *Player Movement
</USE>
</SUMMARY>*/
public class AStar : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Camera camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    [SerializeField]
    private Vector3Int startPos, goalPos;

    private Node current;
    private HashSet<Node> openList;
    private Dictionary<Vector3Int, Node> allNodes = new Dictionary<Vector3Int, Node>();
    private HashSet<Node> closedList;

    private List<Vector3Int> blockedTiles = new List<Vector3Int>();

    private Stack<Vector3> path;

    private void ClearAStar()
    {
        if (current != null)
        {
            allNodes.Clear();
            closedList.Clear();
            openList.Clear();
            path = null;
            current = null;
        }

    }

    public Stack<Vector3> Algorithm(Vector3 postion, Vector3 goal)
    {
        ClearAStar();
        startPos = tilemap.WorldToCell(postion);
        goalPos = tilemap.WorldToCell(goal);
        current = GetNode(startPos);
        openList = new HashSet<Node>();
        closedList = new HashSet<Node>();
        openList.Add(current);
        path = null;

        while (openList.Count > 0 && path == null)
        {
            List<Node> neighbors = FindNeighbors(current.Position);

            ExamineNeighbors(neighbors, current);

            UpdateCurrentTile(ref current);

            path = GeneratePath(current);
        }

        return path;

    }

    private List<Node> FindNeighbors(Vector3Int parentPosition)
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector3Int neighborPos = new Vector3Int(parentPosition.x - x, parentPosition.y - y, parentPosition.z);

                if (y != 0 || x != 0)
                {
                    if (neighborPos != startPos && !blockedTiles.Contains(neighborPos) && tilemap.GetTile(neighborPos))
                    {
                        Node neighbor = GetNode(neighborPos);
                        neighbors.Add(neighbor);
                    }
                }

            }
        }

        return neighbors;
    }

    private void ExamineNeighbors(List<Node> neighbors, Node current)
    {
        for (int i = 0; i < neighbors.Count; i++)
        {
            Node neighbor = neighbors[i];
            
            if (!ConnectedDiag(current, neighbor))
            {
                continue;
            }

            int gScore = DetermineGScore(neighbors[i].Position, current.Position);

            if (openList.Contains(neighbor))
            {
                if (current.G + gScore < neighbor.G)
                {
                    CalcValues(current, neighbor, gScore);
                }
            }
            else if (!closedList.Contains(neighbor))
            {
                CalcValues(current, neighbor, gScore);
                openList.Add(neighbor);
            }
        }
    }

    private void CalcValues(Node parent, Node neighbor, int cost)
    {
        neighbor.Parent = parent;
        neighbor.G = parent.G + cost;
        neighbor.H = ((Math.Abs((neighbor.Position.x - goalPos.x)) + Math.Abs((neighbor.Position.y - goalPos.y))) * 10);
        neighbor.F = neighbor.G + neighbor.H;
    }

    private int DetermineGScore(Vector3Int neighbor, Vector3Int current)
    {
        int x = current.x - neighbor.x;
        int y = current.y - neighbor.y;

        if (Math.Abs(x-y) % 2 == 1)
        {
            return 10;
        }
        else
        {
            return 14;
        }
    }
    private void UpdateCurrentTile(ref Node current)
    {
        openList.Remove(current);
        closedList.Add(current);

        if (openList.Count > 0)
        {
            current = openList.OrderBy(x => x.F).First();
        }
    }


    private Node GetNode(Vector3Int position)
    {
        if (allNodes.ContainsKey(position))
        {
            return allNodes[position];
        }
        else
        {
            Node node = new Node(position);
            allNodes.Add(position, node);
            return node;
        }
    }

    private bool ConnectedDiag(Node currentNode, Node neighbor)
    {
        Vector3Int direct = currentNode.Position - neighbor.Position;
        Vector3Int first = new Vector3Int(current.Position.x + (direct.x *-1), current.Position.y, current.Position.z);
        Vector3Int second = new Vector3Int(current.Position.x, current.Position.y + (direct.y * -1), current.Position.z);
        
        if (blockedTiles.Contains(first) || blockedTiles.Contains(second) || !tilemap.GetTile(first) || !tilemap.GetTile(second))
        {
            return false;
        }
        return true;
    }

    private Stack<Vector3> GeneratePath(Node current)
    {
        if (current.Position == goalPos)
        {
            Stack<Vector3> finalPath = new Stack<Vector3>();

            while(current.Position != startPos)
            {
                finalPath.Push(current.Position);
                current = current.Parent;
            }
            return finalPath;
        }
        return null;
    }

    public void Reset()
    {
        //AStarDebug.thisInstance.Reset(allNodes);
        allNodes.Clear();
        current = null;
        path = null;
    }
}

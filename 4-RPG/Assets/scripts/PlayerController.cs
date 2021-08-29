using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private Vector3 min, max;

    #region PATHFINDING
    private Stack<Vector3> path;
    private Vector3 dest;
    private Vector3 goal;
    private AStar astar;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask layerMask;
    #endregion


    void Start()
    {
        r2dCharPhysics = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        GetInput();
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null)
            {
                Vector3 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
                GetPath(mouseWorldPos);
            }
            }
        ClickToMove();
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, min.x, max.x),
            Mathf.Clamp(transform.position.y, min.y, max.y),
            transform.position.z);

        base.Update();
    }

    private void GetInput()
    {
        v2Direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            v2Direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            v2Direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            v2Direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            v2Direction += Vector2.right;
        }
    }


    public void GetPath(Vector3 goal)
    {
        path = astar.Algorithm(transform.position, goal);
        dest = path.Pop();
        this.goal = goal;
    }

    private void ClickToMove()
    {
        if (path != null)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, dest, fSpeed * Time.deltaTime);

            float distance = Vector2.Distance(dest, transform.parent.position);
            if (distance <= 0f)
            {
                if (path.Count > 0)
                {
                    dest = path.Pop();
                }
                else
                {
                    path = null;
                }
            }
        }
    }

    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }
}

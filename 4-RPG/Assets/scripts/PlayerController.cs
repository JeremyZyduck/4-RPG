using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private Vector3 min, max;

    //RB.velocity = new vector2 (movement.x, movement.y);

    //[SerializeField]
    //private Vector3 moveDirection;

    [SerializeField]
    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;


    #region PATHFINDING
    private Stack<Vector3> path;
    private Vector3 destination;
    private Vector3 goal;
    [SerializeField]
    private AStar astar;
    #endregion

    void Start()
    {
        r2dCharPhysics = GetComponent<Rigidbody2D>();

        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;

        cam = Camera.main;
    }

    protected override void Update()
    {
        
        GetInput();
        ClickToMove();
        base.Update();
    }

    public void GetPath(Vector3 goal)
    {
        Debug.Log("get path started");
        path = astar.Algorithm(transform.position, goal);
        destination = path.Pop();
        this.goal = goal;
    }



    private void ClickToMove()
    {
        if (path != null)
        {
            Debug.Log("movement started");
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, destination, fSpeed * Time.deltaTime);

            float distance = Vector2.Distance(destination, transform.parent.position);

            if (distance <= 0f)
            {
                if (path.Count > 0)
                {
                    destination = path.Pop();
                }
                else
                {
                    path = null;
                }
            }
        }
    }



    void OnGUI()
    {
    }

    private void FixedUpdate()
    {
    }

    private void GetInput()
    {

    }

    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }
}

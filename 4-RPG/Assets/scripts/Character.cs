#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Tilemaps;
#endregion
/*<SUMMARY>
 *All an abstract class holding all shared functions and variables of characters.
<USE>
 *All characters(NPCs and Player Character).
</USE>
</SUMMARY>*/
public abstract class Character : MonoBehaviour
{
    #region TODO
    #endregion
    #region MOVEMENT
    [BoxGroup("Movement"), SerializeField, LabelText("Speed")]
    protected float fSpeed;
    #endregion

    #region PATHFINDING
    protected Stack<Vector3> path;
    [BoxGroup("Pathfinding"), SerializeField, ReadOnly, LabelText("Current Position")]
    protected Vector3 currentPos;
    [BoxGroup("Pathfinding"), SerializeField, Required, LabelText("Astar Script")]
    protected AStar astar;

    [SerializeField]
    protected Vector3 dir;

    [SerializeField]
    private Tilemap tilemap;

    private bool roundedFlag;

    public void GetPath(Vector3 goal)
    {
        roundedFlag = false;
        Debug.Log("Goal " + goal);
        path = astar.Algorithm(transform.position, goal);

        //Don't think this needs to be rounded
        currentPos = RoundVector3(path.Pop());
        //if (path.Peek() == null)
        //{
        //    transform.parent.position = Vector2.MoveTowards(transform.parent.position, RoundVector3(goal), fSpeed * Time.deltaTime);
        //    path = null;
        //}
        dir = (transform.parent.position - goal).normalized;
        dir.Normalize();
    }

    private void Move()
    {
        if (path != null)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, currentPos, fSpeed * Time.deltaTime);
            float distance = Vector2.Distance(currentPos, transform.parent.position); //currentPos and transform.parent.position need to snap to center of their current tile
            
            if (distance <= 0f)
            {
                if (path.Count > 0)
                {
                    currentPos = path.Pop();
                }
                else
                {
                    path = null;
                    if (gameObject.tag == "Player")
                    {
                        gameObject.GetComponent<PlayerController>().AnimationState = 0;
                    }
                }
            }
        }
        else
        {
            path = null;
        }
    }

    Vector3 RoundVector3(Vector3 goal)
    {
        Vector3 rounded;
        if (goal.x > 0 && goal.y > 0)
        {
            rounded = new Vector3(Mathf.Ceil(goal.x), Mathf.Ceil(goal.y), goal.z);
        }
        else if (goal.x < 0 && goal.y > 0)
        {
            rounded = new Vector3(Mathf.Floor(goal.x), Mathf.Ceil(goal.y), goal.z);
        }
        else if (goal.x > 0 && goal.y < 0)
        {
            rounded = new Vector3(Mathf.Ceil(goal.x), Mathf.Floor(goal.y), goal.z);
        }
        else
        {
            rounded = new Vector3(Mathf.Floor(goal.x), Mathf.Floor(goal.y), goal.z);
        }
        return rounded;
    }

    
    #endregion
    #region PHYSICS OBJECT
    //Grabs rigidbody from child
    //All children require the line 'r2dCharPhysics = GetComponent<Rigidbody2D>();' in the start function
    [BoxGroup("Player"), SerializeField, PropertyOrder(-3), LabelText("Rigidbody")]
    protected Rigidbody2D r2dCharPhysics;
    #endregion
    #region DEFAULT
    void Start()
    {
        astar = GetComponent<AStar>();
    }

    protected virtual void Update()
    {
        Move();
        if (path == null && roundedFlag == false)
        {

            Vector3 rounded = RoundVector3(transform.parent.position);

            Debug.Log("Rounded " + rounded);
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, rounded, fSpeed * Time.deltaTime);
            if (transform.parent.position == rounded)
            {
                roundedFlag = true;
            }
            
        }
    }

    private void FixedUpdate()
    {
        
    }
    #endregion
}

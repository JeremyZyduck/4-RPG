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


    public void GetPath(Vector3 goal)
    {
        path = astar.Algorithm(transform.position, goal);
        currentPos = path.Pop();
        dir = (transform.parent.position - goal).normalized;
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
                    GameObject.Find("Player").GetComponent<PlayerController>().AnimationState = 0;
                }
            }
        }
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
    }

    private void FixedUpdate()
    {
    }
    #endregion
}

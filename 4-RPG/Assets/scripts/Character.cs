#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
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
    //Track if in combat, friendly, a follower, or neutral
    #endregion
    #region STATS
    [BoxGroup("Movement"), SerializeField]
    private int health;
    #endregion
    #region MOVEMENT
    [BoxGroup("Movement"), SerializeField, LabelText("Speed")]
    protected float fSpeed;
    #endregion

    #region PATHFINDING
    protected Stack<Vector3> path;
    [BoxGroup("Pathfinding"), SerializeField, ReadOnly, LabelText("Current Position")]
    protected Vector3 currentPos;
    [BoxGroup("Pathfinding"), SerializeField, Required, LabelText("Astar Script"),]
    protected AStar astar;

    

    private void ClickToMove()
    {
        if (path != null)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, currentPos, fSpeed * Time.deltaTime);
            float distance = Vector2.Distance(currentPos, transform.parent.position);
            if (distance <= 0f)
            {
                if (path.Count > 0)
                {
                    currentPos = path.Pop();
                }
                else
                {
                    path = null;
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
        ClickToMove();
        if (health <= 0)
        {
            //DEATH
        }
    }

    private void FixedUpdate()
    {
    }
    #endregion
}

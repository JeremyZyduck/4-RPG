#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
#endregion
/*<SUMMARY>
 *All required functions unique to the player character.
<USE>
 *Player Object.
</USE>
</SUMMARY>*/
public class PlayerController : Character
{
    #region TODO
    //Refactor this and Character.cs to allow all characters to walk
    //Remove MAP LIMITS region and move it to the CameraFollow.cs script
    //Clean up setting astar and the rigidbody
    #endregion
    #region MAP LIMITS
    //WHY IS THIS HERE?
    private Vector3 min, max;
    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }
    #endregion
    #region PATHFINDING
    private Stack<Vector3> path;
    [BoxGroup("Pathfinding"), SerializeField ,ReadOnly, LabelText("Current Position")]
    private Vector3 currentPos;
    [BoxGroup("Pathfinding"), SerializeField, Required, LabelText("Astar Script"), ]
    private AStar astar;

    public void GetPath(Vector3 goal)
    {
        path = astar.Algorithm(transform.position, goal);
        currentPos = path.Pop();
    }

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
    #region DEFAULT
    void Start()
    {
        r2dCharPhysics = GetComponent<Rigidbody2D>();
        astar = GetComponent<AStar>();
    }

    protected override void Update()
    {
        ClickToMove();
        base.Update();
    }
    #endregion
}

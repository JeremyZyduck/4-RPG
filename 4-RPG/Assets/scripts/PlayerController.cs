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
    //Clean up setting astar and the rigidbody
    #endregion

    public void GetPath(Vector3 goal)
    {
        path = astar.Algorithm(transform.position, goal);
        currentPos = path.Pop();
    }

    #region DEFAULT
    void Start()
    {
        r2dCharPhysics = GetComponent<Rigidbody2D>();
        
    }

    protected override void Update()
    {
        base.Update();
    }
    #endregion
}

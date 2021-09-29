using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*<SUMMARY>
 *Allows attached object to follow a game object
<USE>
 *NPC Object. Selected Object
</USE>
</SUMMARY>*/
public class NPCFollow : Character
{
    #region TODO
    //NPC can get "Knocked off course" and stop following
    #endregion


    [SerializeField]
    private GameObject FollowObject;

    protected bool isPathEmpty
    {
        get
        {
            if (path == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    protected override void Update()
    {
        if (FollowObject != null && isPathEmpty)
        {
            GetPath(FollowObject.transform.position);
        }
        base.Update();
    }
}

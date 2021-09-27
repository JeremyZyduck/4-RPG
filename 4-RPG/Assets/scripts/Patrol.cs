using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*<SUMMARY>
 *Allows attached object to "patrol" between a list of locations
<USE>
 *NPC Object.
</USE>
</SUMMARY>*/
public class Patrol : Character
{
    #region TODO
    #endregion

    #region LOCATIONS
    [SerializeField]
    private GameObject[] route;

    [SerializeField]
    private int placeInRoute;

    #endregion

    #region PATROL
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
    #endregion

    #region DEFAULT
    protected override void Update()
    {
        if (route[placeInRoute] != null && isPathEmpty)
        {
            GetPath(route[placeInRoute].transform.position);
            placeInRoute++;
        }
        if (placeInRoute == route.Length)
        {
            placeInRoute = 0;
        }
        base.Update();
    }
    #endregion
}

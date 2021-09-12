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
    //Get list of locations set in inspector
    //Get Rigidbody on start
    //Get path
    #endregion

    #region LOCATIONS
    [SerializeField]
    private Vector3[] PatrolRoute;
    public int placeInPatrol = 0;

    #endregion

    #region PATROL
    protected void patrol(Vector3[] route)
    {
        for (int i = 0; i < route.Length; i++)
        {
            if (route[i] != null)
            {
                GetPath(route[i]);
                //StartCoroutine(WaitForPathToBeNull());
            }
        }
        
    }

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
    /*
    IEnumerator WaitForPathToBeNull()
    {
        while (!isPathEmpty)
        {
            if (isPathEmpty)
            {
                yield return null;
            }
        }
    }
    */
    #endregion


    #region DEFAULT
    private void Start()
    {
        patrol(PatrolRoute);
    }
    #endregion
}

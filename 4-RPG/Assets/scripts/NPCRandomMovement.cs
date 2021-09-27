using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*<SUMMARY>
 *Allows attached object to "Randomly move"
<USE>
 *NPC Object.
</USE>
</SUMMARY>*/
public class NPCRandomMovement : Character
{
    private Vector3 position;
    private int direction;

    [SerializeField]
    private float secondsToWait;
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

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(secondsToWait);
    }

    protected override void Update()
    {
        Debug.Log("Is Path Empty: " + isPathEmpty + "\n Random: " + direction);
        if (isPathEmpty)
        {
            Debug.Log(position == null);

            direction = Random.Range(0, 7);
            switch (direction)
            {
                case 0:
                    position = position + Vector3.up;
                    break;
                case 1:
                    position = position + Vector3.up + Vector3.right;
                    break;
                case 2:
                    position = position + Vector3.right;
                    break;
                case 3:
                    position = position + Vector3.down + Vector3.right;
                    break;
                case 4:
                    position = position + Vector3.down;
                    break;
                case 5:
                    position = position + Vector3.down + Vector3.left;
                    break;
                case 6:
                    position = position + Vector3.left;
                    break;
                case 7:
                    position = position + Vector3.up + Vector3.left;
                    break;
                default:
                    break;
            }

            if (position != null)
            {
                //GET PATH WILL NOT HAVE A GOAL AND BREAK!
                try
                {
                    GetPath(position);
                }
                catch
                {
                    GetPath(gameObject.transform.position);
                }
            }
        }
        base.Update();
    }
}

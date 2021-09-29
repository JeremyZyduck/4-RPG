#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
/*<SUMMARY>
 *Collection of functions and variables that affect the game as a whole.
<USE>
 *Game Object
</USE>
</SUMMARY>*/
public class GameManager : MonoBehaviour
{
    #region TODO
    #endregion

    #region PLAYERINFO
    [SerializeField]
    private string playerName;
    [SerializeField]
    private GameObject Player;
    public void setPlayerName(string name) { playerName = name; }
    public string getPlayerName() { return playerName; }
    #endregion

    #region GAMESTATE
    public bool paused;
    public void FlipInputState()
    {
        if (Player.GetComponent<PlayerController>().enabled == true)
        {
            Player.GetComponent<PlayerController>().enabled = false;
            paused = true;
        }
        else
        {
            Player.GetComponent<PlayerController>().enabled = true;
            paused = false;
        }
    }
    #endregion

    #region DEFAULT
    private void Start()
    {
        paused = false;
    }
    #endregion
}

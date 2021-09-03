using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject AStar;

    public void setPlayerName(string name) { playerName = name; }
    public string getPlayerName() { return playerName; }

    private void Start()
    {
        Player = GameObject.Find("Player");
        AStar = GameObject.Find("AStar");
    }

    public void FlipInputState()
    {
        if (Player.GetComponent<PlayerController>().enabled == false && AStar.GetComponent<AStar>().enabled == false)
        {
            Player.GetComponent<PlayerController>().enabled = true;
            AStar.GetComponent<AStar>().enabled = true;
        }
        else
        {
            Player.GetComponent<PlayerController>().enabled = false;
            AStar.GetComponent<AStar>().enabled = false;
        }
    }

}
